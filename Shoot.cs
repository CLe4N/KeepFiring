using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    SpriteRenderer playerSprite;
    AudioSource GunShotSFX;
    AudioSource ReloadSFX;
    Animator anim;
    Slider ReloadBar_value;
    Hp_con HpStat;
    public Transform bullet_Pos;
    public int damage = 10;
    public GameObject impactEffect;
    public LineRenderer linerenderer;
    public Text AmmoText;
    public int Ammo;
    public GameObject ReloadBar;
    float ReloadTime;
    bool IsReload;
    bool IsShooting;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>(); // access Animator component in children
        GunShotSFX = GameObject.Find("ShotSFX").transform.GetComponent<AudioSource>(); // find "ShotSFX" and access AudioSource component
        ReloadSFX = GameObject.Find("ReloadSFX").transform.GetComponent<AudioSource>(); // find "ReloadSFX" and access AudioSource component
        playerSprite = GetComponentInChildren<SpriteRenderer>(); // access SpriteRenderer component in children
        ReloadBar_value = ReloadBar.transform.GetComponent<Slider>(); // access Slider component
        HpStat = GetComponent<Hp_con>(); // access Hp_con component
    }
    void Update()
    {
        if (HpStat.gameOverStat == false) // if game is not over
        {
            if (Ammo > 0) // if ammo is more than 0
            {
                AmmoText.text = Ammo.ToString(); // show number of ammo
                if (Input.GetKeyDown(KeyCode.Mouse0)) // if left click is press
                {
                    if (IsReload == false) // if player is not reload
                    {
                        StartCoroutine(shooting()); // run method "shooting"
                        Ammo -= 1; // ammo decrease by 1
                        GunShotSFX.Play(); // play "GunShotSFX"
                    }
                }

                if (IsReload == false) // if player is not reload
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1)) // if right click is press
                    {
                        ReloadSFX.Play(); // play "ReloadSFX"
                        anim.SetBool("Reload", true); // play animation reload
                        IsReload = true; // IsReload = ture
                        ReloadTime = 1f; // reload time is 1 second
                        ReloadBar.SetActive(true); // active reload bar
                    }
                }
                else
                {
                    AmmoText.text = "Reloading"; // show text reload
                    if (ReloadTime > 0f) // if reload time is more than 0 second
                    {
                        ReloadTime -= Time.deltaTime; // reloadtime is decrease by 1 per second
                        ReloadBar_value.value += Time.deltaTime; // relaod bar ui is increase by 1 per second
                    }
                    else
                    {
                        anim.SetBool("Reload", false); // stop reload animation
                        Ammo = 18; // give player 18 ammos
                        IsReload = false; // IsReaload = false
                        ReloadBar_value.value = 0; // relaod bar ui is equal 0
                        ReloadBar.SetActive(false); // deactive reload bar
                    }
                }
            }

            if (Ammo <= 0) // if ammo is equal 0
            {
                if (IsReload == false) // if IsReload is false
                {
                    ReloadSFX.Play(); // play "ReloadSFX"
                    anim.SetBool("Reload", true); // play animation reload
                    IsReload = true; // IsReload = ture
                    ReloadTime = 1f; // reload time is 1 second
                    ReloadBar.SetActive(true); // active reload bar
                }
                else
                {
                    AmmoText.text = "Reloading"; // show text reload
                    if (ReloadTime > 0f) // if reload time is more than 0 second
                    {
                        ReloadTime -= Time.deltaTime; //  reloadtime is decrease by 1 per second
                        ReloadBar_value.value += Time.deltaTime; // relaod bar ui is increase by 1 per second
                    }
                    else
                    {
                        anim.SetBool("Reload", false); // stop reload animation
                        Ammo = 18; // give player 18 ammos
                        IsReload = false; //IsReload = false
                        ReloadBar_value.value = 0; // relaod bar ui is equal 0
                        ReloadBar.SetActive(false); // deactive reload bar
                    }
                }
            }
        }
    }

    IEnumerator shooting()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(bullet_Pos.position, bullet_Pos.forward); // create raycast on fire position
        if(hitInfo) // if raycast hit collider
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>(); // access "Enemy" component by variable "enemy"
            MedKit medkit = hitInfo.transform.GetComponent<MedKit>(); // access "MedKit" component by variable "medkit"
            if(enemy != null) // if "enemy" is not empty
            {
                enemy.take_damage(damage); // call method "take_damage"
            }
            if(medkit != null) // if "medkit" is not empty
            {
                medkit.GetHealth(); // call method "GetHealth"
                StartCoroutine(healColor()); // call method "healColor"
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity); // create prefab impactEffect on collider contact position not rotate

            linerenderer.SetPosition(0, bullet_Pos.position); // render line start at fire position
            linerenderer.SetPosition(1, hitInfo.point); // render line end at hit position
        }
        else
        {
            linerenderer.SetPosition(0, bullet_Pos.position); // render line start at fire position
            linerenderer.SetPosition(1, bullet_Pos.position + bullet_Pos.forward*100); // render line end at fire position * 100
        }

        anim.SetBool("Shoot", true); // play "Shoot" animation
        linerenderer.enabled = true; // active linerenderer

        yield return new WaitForSeconds(0.02f); // wait for 0.02 second

        anim.SetBool("Shoot", false); // stop "Shoot" position
        linerenderer.enabled = false; // deactive linerenderer
    }
    IEnumerator healColor()
    {
        playerSprite.color = Color.green; // change player color to green

        yield return new WaitForSeconds(0.2f); // wait for 0.2 second

        playerSprite.color = Color.white; // change player color to normal
    }
}
