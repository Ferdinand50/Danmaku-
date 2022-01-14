using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBoss : MonoBehaviour
{
    public GameObject BossPrefab;
    public float respawnTime;

    // Start is called before the first frame update
    void Start()
    {
           StartCoroutine(BossWave());
    }
        private void spawnEnemy(){
            GameObject a = Instantiate(BossPrefab) as GameObject;

            a.transform.position = new Vector2(0, 5);
            Level1Storage.BossCount ++;

    }
    
    IEnumerator BossWave(){
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.BossCount < 1 ){
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy();    
        }

    }


}
