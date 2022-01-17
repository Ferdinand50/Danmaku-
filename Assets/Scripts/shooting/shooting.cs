using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public Transform playerGun;
    public Transform playerGun1;
    public Transform playerGun2;

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
        if (GlobalVariableStorage.score > 5000) {
            fireRate = 0.1F;
        }
        else if (GlobalVariableStorage.score > 3500) {
            fireRate = 0.25F;
        }
        else if (GlobalVariableStorage.score > 1700) {
            fireRate = 0.1F;
        }
        else if (GlobalVariableStorage.score > 600) {
            fireRate = 0.3F;
        }

    }

    void Shoot ()
    {
        if (GlobalVariableStorage.score > 3500) {
            var playerBullet1 = Instantiate(playerBulletPrefab, playerGun1.position, playerGun1.rotation);
            Physics2D.IgnoreCollision(playerBullet1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            var playerBullet2 = Instantiate(playerBulletPrefab, playerGun2.position, playerGun2.rotation);
            Physics2D.IgnoreCollision(playerBullet2.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(playerBullet1.GetComponent<Collider2D>(), playerBullet2.GetComponent<Collider2D>());

            playerBullet1.tag = "Projectile";
            playerBullet2.tag = "Projectile";
        }
        else {
            var playerBullet = Instantiate(playerBulletPrefab, playerGun.position, playerGun.rotation);
            Physics2D.IgnoreCollision(playerBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            playerBullet.tag = "Projectile";
        }
        
    }
}
