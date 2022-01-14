using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployingCruiser : MonoBehaviour
{
    public GameObject CruiserPrefab;
    public float respawnTime = 12.0f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
           screenBounds = Camera.main.ScreenToWorldPoint(-new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
           StartCoroutine(FrigateWave());
    }
        private void spawnEnemy(){
            GameObject a = Instantiate(CruiserPrefab) as GameObject;
            //spawnPosition at Bounder x and random between ymin and ymax
            //a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
            a.transform.position = new Vector2(0, 5);
            Level1Storage.CruiserCount ++;
            Level1Storage.CruiserCountAlive ++;
        }
    
    IEnumerator FrigateWave(){
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.CruiserCount < 1 && Level1Storage.BossCount < 1)
        {
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy();    
        }

    }


}