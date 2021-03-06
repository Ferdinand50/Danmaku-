using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFrigate : MonoBehaviour
{

    public GameObject FrigatePrefab;

    public float respawnTime = 7.0f;
    public float minx_outside =-8f;
    public float maxx_outside =8f;
    public float y_outside =5f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
           screenBounds = Camera.main.ScreenToWorldPoint(-new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); 
           StartCoroutine(FrigateWave());
           spawnEnemy();
           spawnEnemy();
    }
        private void spawnEnemy(){
            GameObject a = Instantiate(FrigatePrefab) as GameObject;
            //spawnPosition at Bounder x and random between ymin and ymax
            //a.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));
            a.transform.position = GetOutsidePosition();
            Level1Storage.FregatesCount ++;
            Level1Storage.FregatesCountAlive ++;
            Level1Storage.TotalCountAlive++;
            Debug.Log(Level1Storage.FregatesCountDead);
        }
    
    IEnumerator FrigateWave() {
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.FregatesCount < 5 && Level1Storage.BossCount < 1)
        {
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy();
        spawnEnemy();
        }

    }

    Vector2 GetOutsidePosition() {
        float randomOutsideX = Random.Range(minx_outside, maxx_outside);
        return new Vector2(randomOutsideX, y_outside);
    }

}
