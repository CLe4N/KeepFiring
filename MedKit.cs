using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    Hp_con playerHp;
    float coolDown;
    bool IsCoolDown;
    AudioSource healSFX;
    void Start()
    {
        playerHp = GameObject.Find("Player").transform.GetComponent<Hp_con>();
        healSFX = GameObject.Find("HealSFX").transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (IsCoolDown == false)
        {
            coolDown = 5f;
            IsCoolDown = true;
        }
        else
        {
            if (coolDown > 0)
            {
                coolDown -= Time.deltaTime;
            }
            else
            {
                DestroyThis();
            }
        }
    }
    public void GetHealth()
    {
        healSFX.Play();
        DestroyThis();
        playerHp.hp += 1;
    }

    void DestroyThis()
    {
        Destroy(this.gameObject);
    }

}
