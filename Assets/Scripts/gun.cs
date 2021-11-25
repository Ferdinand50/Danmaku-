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

        Instantiate(bulletPrefab, firePointright.position, firePointright.rotation);
        Instantiate(bulletPrefab, firePointleft.position, firePointleft.rotation);
        Instantiate(bulletPrefab, firePointmiddle.position, firePointmiddle.rotation);

    }
}
