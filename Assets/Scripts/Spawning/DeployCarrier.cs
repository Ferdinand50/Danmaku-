using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCarrier : MonoBehaviour
{
    public GameObject CarrierPrefab;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarrierWave());
    }

        private void spawnEnemy(){
            GameObject a = Instantiate(CarrierPrefab) as GameObject;
            //a.transform.position = GetCarrierPosition();
            a.transform.position = new Vector2(0, 5);
            Level1Storage.CarrierCount ++; 
            Level1Storage.CarrierCountAlive ++;
        }
    
    IEnumerator CarrierWave() {
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.CarrierCount < 1 && Level1Storage.BossCount < 1)
        {
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy();
        
        }

    }
}