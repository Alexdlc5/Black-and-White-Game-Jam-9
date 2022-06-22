using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Hit_Player;
    public GameObject Hit_Enemy;
    public GameObject Hit_Wall;
    public bool isEnemyProjectile = false;
    public float speed;
    public float projectile_lifetime;
    public Transform newtransform;
    void Start()
    {
        transform.position = newtransform.position;
        transform.rotation = newtransform.rotation;
    }
    void FixedUpdate()
    {
        transform.position += transform.TransformDirection(Vector3.right) * speed * Time.fixedDeltaTime;
        if (projectile_lifetime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            projectile_lifetime -= Time.fixedDeltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnemyProjectile)
        {
            if (collision.gameObject.tag == "Player")
            {
                Instantiate(Hit_Player).SetActive(true);
                collision.gameObject.GetComponent<Movement>().health--;
            }
            else
            {
                Instantiate(Hit_Wall).SetActive(true);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Instantiate(Hit_Enemy).SetActive(true);
                collision.gameObject.GetComponent<Enemy>().health--;
            }
            else
            {
                Instantiate(Hit_Wall).SetActive(true);
            }
        }
        Destroy(gameObject);
    }
}
