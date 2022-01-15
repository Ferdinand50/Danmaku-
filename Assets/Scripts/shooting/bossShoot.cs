using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShoot : MonoBehaviour
{
    public Transform firePointleftup;
    public Transform firePointmiddleup;
    public Transform firePointrightup;

    public Transform firePointleftcenter;
    public Transform firePointmiddlecenter;
    public Transform firePointrightcenter;

    public Transform firePointleftbot;
    public Transform firePointmiddlebot;
    public Transform firePointrightbot;

    public GameObject bulletBossOnePrefab;
    public GameObject bulletBossTwoPrefab;
    public GameObject bulletBossThreePrefab;
    public GameObject bulletBossFourPrefab;

    private float nextFire = 2.0F;
    //variables for the calculation when to fire
    //Phase 1
    public float fireRateOne = 0.02F;
    //Phase 2
    public float fireRateTwo = 0.3F;
    //Phase 3
    public float fireRateThree = 0.3F;
    //Phase 4
    public float fireRateFour = 0.04F;
    //Phase 5
    public float fireRateFive = 0.3F;

    private int switchShoot = 0;

    // Update is called once per frame
    void Update()
    {
        // Boss phases
        if (Time.time > nextFire)
        {
            
            if ((100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP >= 80)
            {
                ShootOne();
                // calulate when to fire
                nextFire = Time.time + fireRateOne;
            }
            //First threshold 85%
            if ((100*GlobalVariableStorage.BossHP)/ GlobalVariableStorage.BossMaxHP < 80 && (100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP >= 60)
            {
                ShootTwo();
                // calulate when to fire
                nextFire = Time.time + fireRateTwo;
            }
            //Second threshold 60%
            if ((100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP < 60 && (100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP >= 40)
            { 
                ShootThree();
                // calulate when to fire
                nextFire = Time.time + fireRateThree;
            }
            //Third threshold 40%
            if ((100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP < 40 && (100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP >= 20)
            {
                ShootFour();
                // calulate when to fire
                nextFire = Time.time + fireRateFour;
            }
            //Last threshold 20%
            if ((100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP < 20 && (100 * GlobalVariableStorage.BossHP) / GlobalVariableStorage.BossMaxHP > 0)
            {
                ShootFive();
                // calulate when to fire
                nextFire = Time.time + fireRateFive;
            }


        }
    }

    void ShootOne()
    {
        float randomRotation = Random.Range(2, 6);
        firePointrightbot.Rotate(0.0f, 0.0f, randomRotation);
        firePointmiddlebot.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftbot.Rotate(0.0f, 0.0f, randomRotation);

        firePointrightcenter.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftcenter.Rotate(0.0f, 0.0f, randomRotation);

        firePointrightup.Rotate(0.0f, 0.0f, randomRotation);
        firePointmiddleup.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftup.Rotate(0.0f, 0.0f, randomRotation);

        var bulletRightBot = Instantiate(bulletBossOnePrefab, firePointrightbot.position, firePointrightbot.rotation);
        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMidBot = Instantiate(bulletBossOnePrefab, firePointmiddlebot.position, firePointmiddlebot.rotation);
        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftBot = Instantiate(bulletBossOnePrefab, firePointleftbot.position, firePointleftbot.rotation);
        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var bulletRightCenter = Instantiate(bulletBossOnePrefab, firePointrightcenter.position, firePointrightcenter.rotation);
        Physics2D.IgnoreCollision(bulletRightCenter.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftCenter = Instantiate(bulletBossOnePrefab, firePointleftcenter.position, firePointleftcenter.rotation);
        Physics2D.IgnoreCollision(bulletLeftCenter.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var bulletRightUp = Instantiate(bulletBossOnePrefab, firePointrightup.position, firePointrightup.rotation);
        Physics2D.IgnoreCollision(bulletRightUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMidUp = Instantiate(bulletBossOnePrefab, firePointmiddleup.position, firePointmiddleup.rotation);
        Physics2D.IgnoreCollision(bulletMidUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftUp = Instantiate(bulletBossOnePrefab, firePointleftup.position, firePointleftup.rotation);
        Physics2D.IgnoreCollision(bulletLeftUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), bulletLeftBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), bulletMidBot.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), bulletRightBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), bulletMidBot.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), bulletRightBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), bulletLeftBot.GetComponent<Collider2D>());

        bulletLeftBot.tag = "EnemyProjectileTraverse";
        bulletMidBot.tag = "EnemyProjectileTraverse";
        bulletRightBot.tag = "EnemyProjectileTraverse";
        bulletLeftCenter.tag = "EnemyProjectileTraverse";
        bulletRightCenter.tag = "EnemyProjectileTraverse";
        bulletLeftUp.tag = "EnemyProjectileTraverse";
        bulletMidUp.tag = "EnemyProjectileTraverse";
        bulletRightUp.tag = "EnemyProjectileTraverse";

    }
    void ShootTwo()
    {
        float randomRotation = Random.Range(-180, 180);
        firePointmiddlecenter.Rotate(0.0f, 0.0f, randomRotation);
        var bulletZero = Instantiate(bulletBossTwoPrefab, firePointmiddlecenter.position, firePointmiddlecenter.rotation);
        Physics2D.IgnoreCollision(bulletZero.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        bulletZero.tag = "EnemyProjectileTraverse";
    }
    void ShootThree()
    {
        float randomRotation = Random.Range(0, 10);
        firePointrightbot.Rotate(0.0f, 0.0f, randomRotation);
        firePointmiddlebot.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftbot.Rotate(0.0f, 0.0f, randomRotation);

        firePointrightcenter.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftcenter.Rotate(0.0f, 0.0f, randomRotation);

        firePointrightup.Rotate(0.0f, 0.0f, randomRotation);
        firePointmiddleup.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftup.Rotate(0.0f, 0.0f, randomRotation);

        var bulletRightBot = Instantiate(bulletBossThreePrefab, firePointrightbot.position, firePointrightbot.rotation);
        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMidBot = Instantiate(bulletBossThreePrefab, firePointmiddlebot.position, firePointmiddlebot.rotation);
        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftBot = Instantiate(bulletBossThreePrefab, firePointleftbot.position, firePointleftbot.rotation);
        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var bulletRightCenter = Instantiate(bulletBossThreePrefab, firePointrightcenter.position, firePointrightcenter.rotation);
        Physics2D.IgnoreCollision(bulletRightCenter.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftCenter = Instantiate(bulletBossThreePrefab, firePointleftcenter.position, firePointleftcenter.rotation);
        Physics2D.IgnoreCollision(bulletLeftCenter.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var bulletRightUp = Instantiate(bulletBossThreePrefab, firePointrightup.position, firePointrightup.rotation);
        Physics2D.IgnoreCollision(bulletRightUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMidUp = Instantiate(bulletBossThreePrefab, firePointmiddleup.position, firePointmiddleup.rotation);
        Physics2D.IgnoreCollision(bulletMidUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftUp = Instantiate(bulletBossThreePrefab, firePointleftup.position, firePointleftup.rotation);
        Physics2D.IgnoreCollision(bulletLeftUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), bulletLeftBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), bulletMidBot.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), bulletRightBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), bulletMidBot.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), bulletRightBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), bulletLeftBot.GetComponent<Collider2D>());

        bulletLeftBot.tag = "EnemyProjectileTraverse";
        bulletMidBot.tag = "EnemyProjectileTraverse";
        bulletRightBot.tag = "EnemyProjectileTraverse";
        bulletLeftCenter.tag = "EnemyProjectileTraverse";
        bulletRightCenter.tag = "EnemyProjectileTraverse";
        bulletLeftUp.tag = "EnemyProjectileTraverse";
        bulletMidUp.tag = "EnemyProjectileTraverse";
        bulletRightUp.tag = "EnemyProjectileTraverse";

    }

    void ShootFour()
    {
        float randomRotation = Random.Range(-45f, 45f);
        firePointrightbot.Rotate(0.0f, 0.0f, randomRotation);
        firePointmiddlebot.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftbot.Rotate(0.0f, 0.0f, randomRotation);

        firePointrightcenter.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftcenter.Rotate(0.0f, 0.0f, randomRotation);

        firePointrightup.Rotate(0.0f, 0.0f, randomRotation);
        firePointmiddleup.Rotate(0.0f, 0.0f, randomRotation);
        firePointleftup.Rotate(0.0f, 0.0f, randomRotation);

        var bulletRightBot = Instantiate(bulletBossFourPrefab, firePointrightbot.position, firePointrightbot.rotation);
        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMidBot = Instantiate(bulletBossFourPrefab, firePointmiddlebot.position, firePointmiddlebot.rotation);
        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftBot = Instantiate(bulletBossFourPrefab, firePointleftbot.position, firePointleftbot.rotation);
        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var bulletRightCenter = Instantiate(bulletBossFourPrefab, firePointrightcenter.position, firePointrightcenter.rotation);
        Physics2D.IgnoreCollision(bulletRightCenter.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftCenter = Instantiate(bulletBossFourPrefab, firePointleftcenter.position, firePointleftcenter.rotation);
        Physics2D.IgnoreCollision(bulletLeftCenter.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        var bulletRightUp = Instantiate(bulletBossFourPrefab, firePointrightup.position, firePointrightup.rotation);
        Physics2D.IgnoreCollision(bulletRightUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletMidUp = Instantiate(bulletBossFourPrefab, firePointmiddleup.position, firePointmiddleup.rotation);
        Physics2D.IgnoreCollision(bulletMidUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        var bulletLeftUp = Instantiate(bulletBossFourPrefab, firePointleftup.position, firePointleftup.rotation);
        Physics2D.IgnoreCollision(bulletLeftUp.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), bulletLeftBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletRightBot.GetComponent<Collider2D>(), bulletMidBot.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), bulletRightBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletLeftBot.GetComponent<Collider2D>(), bulletMidBot.GetComponent<Collider2D>());

        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), bulletRightBot.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(bulletMidBot.GetComponent<Collider2D>(), bulletLeftBot.GetComponent<Collider2D>());

        bulletLeftBot.tag = "EnemyProjectileTraverse";
        bulletMidBot.tag = "EnemyProjectileTraverse";
        bulletRightBot.tag = "EnemyProjectileTraverse";
        bulletLeftCenter.tag = "EnemyProjectileTraverse";
        bulletRightCenter.tag = "EnemyProjectileTraverse";
        bulletLeftUp.tag = "EnemyProjectileTraverse";
        bulletMidUp.tag = "EnemyProjectileTraverse";
        bulletRightUp.tag = "EnemyProjectileTraverse";

    }

    void ShootFive()
    {
        ShootOne();
        if (switchShoot == 0 )
        {
            ShootTwo();
        }
        if (switchShoot == 10)
        {
            ShootThree();
        }
        if ((switchShoot/4)*4 == switchShoot)
        {
            
            ShootFour();
        }


        switchShoot++;
        if (switchShoot== 20){
            switchShoot =0;
        }
    }
}
