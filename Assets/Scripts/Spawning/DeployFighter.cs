using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployFighter : MonoBehaviour
{
    public GameObject FighterPrefab;
    public float respawnTime = 1.0f;
    public float minx_outside =-8f;
    public float maxx_outside =8f;
    public float y_outside =5f;
    Vector2 CarrierPosition;
    //let the fighter spawn more upper
    Vector2 PosYPlus;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PosYPlus = new Vector2(0, 1);
        StartCoroutine(FighterWave());
    }

        private void spawnEnemy(){
            GameObject a = Instantiate(FighterPrefab) as GameObject;
            //a.transform.position = GetCarrierPosition();
            a.transform.position = CarrierPosition;
            Level1Storage.FregatesCount ++;
            Level1Storage.TotalCountAlive++;
            Level1Storage.FregatesCountAlive ++; 
        }
    //spawns figher if the carrier exist
    IEnumerator FighterWave() {
        // change this to boolean to stop spawning if certain things happend
        while(Level1Storage.FighterCount < 15 && Level1Storage.BossCount < 1)
        {
        yield return new WaitForSeconds(respawnTime);
        var CarrierObject = GameObject.Find("Carrier(Clone)");
        if(CarrierObject){
            CarrierPosition = CarrierObject.transform.position;
            CarrierPosition = CarrierPosition+PosYPlus;
            spawnEnemy();
        }
        }

    }


}