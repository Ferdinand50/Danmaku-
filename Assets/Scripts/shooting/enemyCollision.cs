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
        
    }
    // Update is called once per frame
    void Update()
    {
        if (healthPoints == 0)
        {
            if (gameObject.name.Contains("Cruiser") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 500;
                Level1Storage.CruiserCountDead ++;
                Level1Storage.CruiserCountAlive --;
            }
            if (gameObject.name.Contains("Frigate") == true)
            {
                GlobalVariableStorage.score = GlobalVariableStorage.score + 100;
                Level1Storage.FregatesCountDead ++;
                Level1Storage.FregatesCountAlive --;
            }
            if (gameObject.name.Contains("Fighter") == true)
            {
                //GlobalVariableStorage.score = GlobalVariableStorage.score + 500;
                Level1Storage.FighterCountDead ++;
                Level1Storage.FighterCountAlive --;
            }
            if (gameObject.name.Contains("Carrier") == true)
            {
                //GlobalVariableStorage.score = GlobalVariableStorage.score + 100;
                Level1Storage.CarrierCountDead ++;
                Level1Storage.CarrierCountAlive --;
            }
            if (gameObject.name.Contains("Boss") == true)
            {
                //GlobalVariableStorage.score = GlobalVariableStorage.score + 500;
                Level1Storage.BossCountDead ++;
                Level1Storage.BossCountAlive --;
            }
            if (gameObject.name.Contains("Supporter") == true)
            {
                //GlobalVariableStorage.score = GlobalVariableStorage.score + 100;
                Level1Storage.SupporterCountDead ++;
                Level1Storage.SupporterCountAlive --;
            }
            Destroy(gameObject);
            
        }
    }
}
