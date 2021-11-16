using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
     
    public Transform firePointleft;
    public Transform firePointright;
    public Transform firePointmiddle;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot ()
    {

        Instantiate(bulletPrefab, firePointright.position, firePointright.rotation);
        Instantiate(bulletPrefab, firePointleft.position, firePointleft.rotation);
        Instantiate(bulletPrefab, firePointmiddle.position, firePointmiddle.rotation);

    }
}
