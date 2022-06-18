using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject spawn;
    public GameObject Bullet;
    public bool isEnemy = false;
    void Update()
    {
        if (!isEnemy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shoot();
            }
        }
    }
    //called by player wanting shoot or enemy wanting to shoot
    public void shoot()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.GetComponent<Projectile>().newtransform = transform;
        bullet.GetComponent<Projectile>().isEnemyProjectile = isEnemy;
    }
}
