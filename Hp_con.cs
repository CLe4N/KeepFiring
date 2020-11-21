using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_con : MonoBehaviour
{
    public Image[] heart;
    public int hp = 3;
    SpriteRenderer bodyRenderer;
    public GameObject Gameover_Ui;
    public bool gameOverStat;
    public AudioSource StageBGM;
    public AudioSource hurtSFX;

    void Start()
    {
        bodyRenderer = GetComponentInChildren<SpriteRenderer>(); // access SpriteRenderer component in this gameobject Children
        Time.timeScale = 1; // timescale = 1
    }

    void Update()
    {
        if(hp >3) // if hp more than 3
        {
            hp = 3; // hp = 3
        }
        if(hp == 3) // if hp = 3
        {
            heart[0].color = Color.white; // all 3 heart ui is active   
            heart[1].color = Color.white;
            heart[2].color = Color.white;
        }
        if(hp == 2) // if hp = 2
        {
            heart[0].color = Color.white; // 2 heart ui is active
            heart[1].color = Color.white;
            heart[2].color = Color.black;
        }
        if(hp == 1) // if hp = 1
        {
            heart[0].color = Color.white; // 1 heart ui is active
            heart[1].color = Color.black;
            heart[2].color = Color.black;
        }
        if(hp == 0) // if hp = 0
        {
            heart[0].color = Color.black; //all 3 heart ui is deactive
            heart[1].color = Color.black;
            heart[2].color = Color.black;
            Gameover_Ui.SetActive(true);
            gameOverStat = true;
            StageBGM.Stop();
            Time.timeScale = 0;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) // if collide with gameobject with tag "Enemy"
        {
            hp -= 1; // hp - 1
            hurtSFX.Play(); // play "hurtSFX"
            StartCoroutine(hurtColor()); // run method "hurtColor"
            Destroy(collision.gameObject); // destroy collided gameobject
        }
    }

    IEnumerator hurtColor()
    {
        bodyRenderer.color = Color.red; // change color to red

        yield return new WaitForSeconds(0.2f); // wait for 0.2 sec

        bodyRenderer.color = Color.white; // change color to white
    }
}
