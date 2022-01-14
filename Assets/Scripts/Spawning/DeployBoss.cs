using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBoss : MonoBehaviour
{
    public GameObject BossPrefab;
    public float respawnTime;

    // Start is called before the first frame update
    void start()
    {
           StartCoroutine(BossWave());
    }
        private void spawnEnemy(){
            GameObject a = Instantiate(BossPrefab) as GameObject;

            a.transform.position = new Vector2(0, 5);
            Level1Storage.BossCount ++;
<<<<<<< HEAD

=======
            Level1Storage.BossCountAlive ++;
            //var CarrierObject = GameObject.Find("Carrier(Clone)");
            //while (CarrierObject){
            //    Destroy(CarrierObject);
            //}
            
>>>>>>> 6dcb191e3e9f9d9f454e3ac0fb032f10b17fc4b3
    }
    
    IEnumerator BossWave(){
        // change this to boolean to stop spawning if certain things happend
        Debug.Log("hello");
        if(Level1Storage.FregatesCountDead == 2){
        Debug.Log("here");
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy();    
        }

    }


}
