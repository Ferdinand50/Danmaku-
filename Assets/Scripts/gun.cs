using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firePointleft;
    public Transform firePointright;
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

        var bulletRight = Instantiate(bulletPrefab, firePointright.position, firePointright.rotation);
        Physics2D.IgnoreCollision(bulletRight.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeft = Instantiate(bulletPrefab, firePointleft.position, firePointleft.rotation);
        Physics2D.IgnoreCollision(bulletLeft.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMid = Instantiate(bulletPrefab, firePointmiddle.position, firePointmiddle.rotation);
        Physics2D.IgnoreCollision(bulletMid.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletRight.GetComponent<Collider2D>(), bulletLeft.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletRight.GetComponent<Collider2D>(), bulletMid.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletLeft.GetComponent<Collider2D>(), bulletRight.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletLeft.GetComponent<Collider2D>(), bulletMid.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletMid.GetComponent<Collider2D>(), bulletRight.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletMid.GetComponent<Collider2D>(), bulletLeft.GetComponent<Collider2D>());

    }
}
