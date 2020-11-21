using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ZombiePrefab;
    AudioSource zombieRoar;
    bool IsRespawn;
    float coolDown;

    float spawnCD;
    float SpawnTime = 2.5f;
    bool Is_CD;

    private void Start()
    {
        zombieRoar = GameObject.Find("ZombieRoar").transform.GetComponent<AudioSource>(); // find "ZombieRoar" and access AudioSource Component
    }
    void Update()
    {
        if (SpawnTime > 0.99) // if spawntime more than 0.99
        {
            if (Is_CD == false) // if Is_CD = false
            {
                spawnCD = 10; // spawnCD = 10
                Is_CD = true; // Is_CD = true
            }
            else
            {
                if (spawnCD > 0) // if spawnCD more than 0
                {
                    spawnCD -= Time.deltaTime; // spawnCD decrease by 1 per second
                }
                else
                {
                    Is_CD = false; // Is_CD = false
                    spawnCD = 0; // spawnCD = 0
                    SpawnTime -= 0.2f; // SpawnTime decrease by 0.2
                }
            }
        }
        Respawn(SpawnTime); // call method Respawn
    }

    void Respawn(float RespawmCD)
    {
        if (IsRespawn == false) // if IsRespawn == false
        {
            Instantiate(ZombiePrefab, new Vector2(Random.Range(-6, 6), transform.position.y), Quaternion.identity); 
            // create prefab ZombiePrefab x position random between -6 to 6 
            zombieRoar.Play(); // play zombieRoar
            IsRespawn = true; // IsRespawn = true
            coolDown = RespawmCD; // coolDown = RespawmCD
        }
        if(IsRespawn == true) // if IsRespawn == true
        {
            if(coolDown > 0) // if coolDown > 0
            {
                coolDown -= Time.deltaTime; // coolDown decrease by 1 per sec
            }
            else
            {
                IsRespawn = false; // IsRespawn = false;
            }
        }
    }
}
