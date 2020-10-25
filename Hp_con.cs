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
        bodyRenderer = GetComponentInChildren<SpriteRenderer>();
        Time.timeScale = 1;
    }

    void Update()
    {
        if(hp >3)
        {
            hp = 3;
        }
        if(hp == 3)
        {
            heart[0].color = Color.white;
            heart[1].color = Color.white;
            heart[2].color = Color.white;
        }
        if(hp == 2)
        {
            heart[0].color = Color.white;
            heart[1].color = Color.white;
            heart[2].color = Color.black;
        }
        if(hp == 1)
        {
            heart[0].color = Color.white;
            heart[1].color = Color.black;
            heart[2].color = Color.black;
        }
        if(hp == 0)
        {
            heart[0].color = Color.black;
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
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hp -= 1;
            hurtSFX.Play();
            StartCoroutine(hurtColor());
            Destroy(collision.gameObject);
        }
    }

    IEnumerator hurtColor()
    {
        bodyRenderer.color = Color.red;

        yield return new WaitForSeconds(0.2f);

        bodyRenderer.color = Color.white;
    }
}
