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
        playerHp = GameObject.Find("Player").transform.GetComponent<Hp_con>(); // find gameobject "Player" and access Hp_con component
        healSFX = GameObject.Find("HealSFX").transform.GetComponent<AudioSource>(); // find gameobject "AudioSource" and access Hp_con component
    }

    void Update()
    {
        if (IsCoolDown == false) // if IsCoolDown is false
        {
            coolDown = 5f; // cooldown time = 5 sec
            IsCoolDown = true; // IsCoolDown is true
        }
        else
        {
            if (coolDown > 0) // if cooldown more than 0
            {
                coolDown -= Time.deltaTime; // cooldown time is decrease 1 per second
            }
            else
            {
                DestroyThis(); // run method "DestroyThis"
            }
        }
    }
    public void GetHealth()
    {
        healSFX.Play(); // play "healSFX"
        DestroyThis(); // run method "DestroyThis"
        playerHp.hp += 1; // player hp + 1
    }

    void DestroyThis()
    {
        Destroy(this.gameObject); // destroy this gameobject
    }

}
