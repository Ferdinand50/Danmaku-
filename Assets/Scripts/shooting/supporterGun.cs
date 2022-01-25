using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supporterGun : MonoBehaviour
{
        public Transform firePointmiddle;
        public GameObject bulletPrefab;

        //variables for the calculation when to fire
        public float fireRate = 0.5F;
        private float fireRateIntraWave = 0.0015F;
        private float nextFire = 0.0F;
        private float bulletCount = 60;

        // Update is called once per frame
        void Update()
        {

            if (Time.time > nextFire)
            {
                if (bulletCount == 0)
                {
                    RotateFirePoint();
                    bulletCount = 60;
                    nextFire = Time.time + fireRate;
                } else
                {
                    Shoot();
                    bulletCount--;
                    firePointmiddle.Rotate(0.0f, 0.0f, 30);
                    nextFire = Time.time + fireRateIntraWave;
                }
                
                // calulate when to fire
                
            }
        }

        void RotateFirePoint()
        {
            float randomRotation = Random.Range(-10, 10);
            firePointmiddle.Rotate(0.0f, 0.0f, randomRotation);
        }
        void Shoot()
        {
            
            var bulletMid = Instantiate(bulletPrefab, firePointmiddle.position, firePointmiddle.rotation);
            Physics2D.IgnoreCollision(bulletMid.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            bulletMid.tag = "EnemyProjectileTraverse";

        }
}
