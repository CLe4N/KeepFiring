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
        Score = GameObject.Find("Score").transform.GetComponent<Score>();
        player = GameObject.Find("Player").transform.GetComponent<Transform>();
        DeathSFX = GameObject.Find("ZombieDeath").transform.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rotate();
        moveCharacter(movement);
    }

    public void take_damage(int Damage)
    {
        Enemy_Health -= Damage;
        if(Enemy_Health <= 0)
        {
            Score.ScorePoint += 10;
            die();
        }
    }

    void die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        DeathSFX.Play();
        int randomStat = Random.Range(0, 3);
        if(randomStat < 1)
        {
            Instantiate(MedKit, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void rotate()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction *(moveSpeed * Time.deltaTime)));
    }
}
