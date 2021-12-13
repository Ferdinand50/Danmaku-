using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFrigate : MonoBehaviour
{

    public GameObject FrigatePrefab;

    public float respawnTime = 7.0f;
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
            a.transform.position = GetRandomPosition();
            Level1Storage.FregatesCount ++; 
        }
    
    IEnumerator FrigateWave() {
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.FregatesCount < 5){
        yield return new WaitForSeconds(respawnTime);
        spawnEnemy();
        }

    }

    Vector2 GetRandomPosition() {
        float randomX = Random.Range(-8, 8);
        float randomY = Random.Range(-0, 3);
        return new Vector2(randomX, randomY);
    }

}
