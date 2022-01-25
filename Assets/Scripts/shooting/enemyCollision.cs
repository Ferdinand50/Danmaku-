using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int healthPoints;

    void Start()
    {
        if (gameObject.name.Contains("Boss") == true)
        {
            healthPoints = GlobalVariableStorage.BossMaxHP;
            GlobalVariableStorage.BossHP = healthPoints;
        }
        else if (gameObject.name.Contains("Cruiser") == true)
        {
            healthPoints = 10 + GlobalVariableStorage.score/60;
        }
        else if (gameObject.name.Contains("Frigate") == true)
        {
            healthPoints = 10 + GlobalVariableStorage.score/75;
        }
        else if (gameObject.name.Contains("Fighter") == true)
        {
            healthPoints = 1 + GlobalVariableStorage.score/1200;
        }
        else if (gameObject.name.Contains("Carrier") == true) //MidBoss => more powerful
        {
            healthPoints = 50 + GlobalVariableStorage.score/30;
        }
        else if (gameObject.name.Contains("Supporter") == true)
        {
            healthPoints = 20 + GlobalVariableStorage.score/150;
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EnemyProjectile")
        {
        Physics.IgnoreCollision(coll.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

        if (coll.gameObject.CompareTag("Projectile"))
        {
            Destroy(coll.gameObject);
            healthPoints = healthPoints - 1;
        }
        if (gameObject.name.Contains("Boss") == true)
        {
            GlobalVariableStorage.BossHP = healthPoints;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            if (gameObject.name.Contains("Cruiser") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 200;
                Level1Storage.CruiserCountDead ++;
                Level1Storage.CruiserCountAlive --;
                Level1Storage.TotalCountAlive--;
            }
            if (gameObject.name.Contains("Frigate") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 100;
                Level1Storage.FregatesCountDead ++;
                Level1Storage.FregatesCountAlive --;
                Level1Storage.TotalCountAlive--;
            }
            if (gameObject.name.Contains("Fighter") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 50;
                Level1Storage.FighterCountDead ++;
                Level1Storage.FighterCountAlive --;
                Level1Storage.TotalCountAlive--;
            }
            if (gameObject.name.Contains("Carrier") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 250;
                Level1Storage.CarrierCountDead ++;
                Level1Storage.CarrierCountAlive --;
                Level1Storage.TotalCountAlive--;
            }
            if (gameObject.name.Contains("Boss") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 1000;
                Level1Storage.BossCountDead ++;
                Level1Storage.BossCountAlive --;
                Level1Storage.TotalCountAlive--;
            }
            if (gameObject.name.Contains("Supporter") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 100;
                Level1Storage.SupporterCountDead ++;
                Level1Storage.SupporterCountAlive --;
                Level1Storage.TotalCountAlive--;
            }
            Destroy(gameObject);
            
        }
    }
}
