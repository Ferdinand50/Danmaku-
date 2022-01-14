using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySupporter : MonoBehaviour
{
    public GameObject SupporterPrefab;
    public float respawnTime;

    // Start is called before the first frame update
    void Start()
    {
           StartCoroutine(FrigateWave());
    }
        private void spawnEnemy(){
            GameObject a = Instantiate(SupporterPrefab) as GameObject;

            a.transform.position = new Vector2(0, 5);
            Level1Storage.SupporterCount ++;
            Level1Storage.SupporterCountAlive ++;
        }
    
    IEnumerator FrigateWave(){
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.SupporterCount < 6 && Level1Storage.BossCount < 1)
        {
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy(); 
            }   
        
    }


}