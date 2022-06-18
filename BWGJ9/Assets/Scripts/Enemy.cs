using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float health = 3;

    public bool canMove = false;
    public float moving_speed;
    private GameObject Player;
    public float shooting_speed;
    private float shooting_timer;
    public GameObject GunRotator;
    public GameObject ProjectileSpawn;
    private float distance_from_player;
    public float agro_range;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance_from_player = MathF.Sqrt(Mathf.Pow(Player.transform.position.x - transform.position.x, 2) + Mathf.Pow(Player.transform.position.y - transform.position.y, 2));
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        GunRotator.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));
        if (distance_from_player < agro_range)
        {
            if (shooting_timer <= 0)
            {
                ProjectileSpawn.GetComponent<Shoot>().shoot();
                shooting_timer = shooting_speed;
            }
            else
            {
                shooting_timer -= Time.deltaTime;
            }

            if (canMove)
            {
                float movement_direction = 0;
                if (Player.transform.position.x <= transform.position.x)
                {
                    movement_direction = -1;
                }
                else
                {
                    movement_direction = 1;
                }
                transform.position += Vector3.right * movement_direction * moving_speed * Time.fixedDeltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
