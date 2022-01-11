using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleGun : MonoBehaviour
{
    public Transform firePointmiddle;
    public GameObject bulletPrefab;

    //variables for the calculation when to fire
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextFire) {
            Shoot();
            // calulate when to fire
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot ()
    {

        var bulletMid = Instantiate(bulletPrefab, firePointmiddle.position, firePointmiddle.rotation);
        Physics2D.IgnoreCollision(bulletMid.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        bulletMid.tag = "EnemyProjectileTraverse";

    }
}