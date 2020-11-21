using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Enemy_Health = 30;
    public GameObject DeathEffect;
    public GameObject MedKit;
    float moveSpeed = 5f;
    Vector2 movement;
    Transform player;
    Rigidbody2D rb;
    AudioSource DeathSFX;
    Score Score;

    void Start()
    {
        Score = GameObject.Find("Score").transform.GetComponent<Score>(); // Find gameobject "Score" and access score component
        player = GameObject.Find("Player").transform.GetComponent<Transform>(); // Find gameobject "Player" and access Transform component
        DeathSFX = GameObject.Find("ZombieDeath").transform.GetComponent<AudioSource>(); // Find gameobject "ZombieDeath" and access AudioSource component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rotate();
        moveCharacter(movement);
    }

    public void take_damage(int Damage)
    {
        Enemy_Health -= Damage; // enemy get damage value
        if(Enemy_Health <= 0) // do if enemy health is less than 0
        {
            Score.ScorePoint += 10; // score plus 10
            die();
        }
    }

    void die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity); // create prefab "DeathEffect" on this gameobject position and not rotate
        DeathSFX.Play(); // play "DeathSFX"
        int randomStat = Random.Range(0, 3); // random number between 0 to 3
        if(randomStat < 1) // if number is less than 1
        {
            Instantiate(MedKit, transform.position, Quaternion.identity); // create prefab "MedKit" on this gameobject position not rotate
        }
        Destroy(gameObject); // destroy this gameobject
    }

    void rotate()
    {
        Vector3 direction = player.position - transform.position; // calculate player directon
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // calculate player angle 
        rb.rotation = angle; // rotate to calculated angle
        direction.Normalize(); // normalize direction value to 1 , 0 , -1
        movement = direction; // movement equal direction
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction *(moveSpeed * Time.deltaTime))); // move to player 
    }
}
