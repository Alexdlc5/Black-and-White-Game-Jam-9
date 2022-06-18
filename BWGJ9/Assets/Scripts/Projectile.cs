using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
                collision.gameObject.GetComponent<Movement>().health--;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().health--;
            }
        }
        Destroy(gameObject);
    }
}
