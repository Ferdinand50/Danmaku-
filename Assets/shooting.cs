using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Transform playerGun;

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

        var playerBullet = Instantiate(playerBulletPrefab, playerGun.position, playerGun.rotation);
        Physics2D.IgnoreCollision(playerBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
