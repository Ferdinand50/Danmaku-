using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public GameObject Fregate;
    public GameObject Cruiser;
    public GameObject Carrier;
    public GameObject Supporter;
    Vector2 targetPosition;
    public float timeToSpawn;
    private float currentTimeToSpawn;
    private bool FrigateSpawned = true;
    private bool SupporterSpawned = true;
    private bool CarrierSpawned = true;
    private bool ReadyForBoss = false;
    private bool BossSpawned = true;
    private bool BossDead = false;

    void Start()
    {
        
        SpawnObjectFregate();
        SpawnObjectFregate();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Level1Storage.FregatesCount == 2 & Level1Storage.FregatesCountDead == 2){
        SpawnObjectFregate();
        SpawnObjectFregate();
        }
        if(Level1Storage.FregatesCount == 4 & Level1Storage.FregatesCountDead == 3 & FrigateSpawned){
        SpawnObjectCruiser();
        FrigateSpawned = false;
        }
        if(Level1Storage.FregatesCount == 4 & Level1Storage.CruiserCountDead == 1){
        SpawnObjectFregate();
        SpawnObjectFregate();
        }
        if(Level1Storage.CruiserCount == 1 & Level1Storage.FregatesCountDead == 6){
        SpawnObjectFregate();
        SpawnObjectFregate();
        SpawnObjectCruiser();
        }
        if(Level1Storage.CruiserCount == 2 & Level1Storage.FregatesCountDead == 8 & SupporterSpawned){
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        SupporterSpawned = false;
        }
        if(Level1Storage.SupporterCountDead == 2 & Level1Storage.SupporterCount == 2) {
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        }
        if(Level1Storage.SupporterCountDead == 6 & Level1Storage.SupporterCount == 6 & CarrierSpawned) {
        SpawnObjectCarrier();
        CarrierSpawned = false;
        }
        if(Level1Storage.CarrierCountDead == 1 & Level1Storage.SupporterCount ==6) {
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        SpawnObjectCruiser();
        }
        if(Level1Storage.SupporterCountDead ==8 & Level1Storage.SupporterCount ==8) {
        SpawnObjectFregate();
        SpawnObjectSupporter();
        SpawnObjectCruiser();
        ReadyForBoss = true;
        }
        if(ReadyForBoss & BossSpawned & Level1Storage.SupporterCountDead == 9) {
        SpawnObjectBoss();
        BossSpawned = false;
        }
    }
    
    public void SpawnObjectBoss(){
        targetPosition = GetRandomPosition();
        Instantiate(Boss, transform.position, Boss.transform.rotation);
        Level1Storage.BossCount ++;
        Level1Storage.BossCountAlive ++;
    }
    
    public void SpawnObjectFregate(){
        targetPosition = GetRandomPosition();
        Instantiate(Fregate, targetPosition, transform.rotation);
        Level1Storage.FregatesCount ++;
        Level1Storage.FregatesCountAlive ++;
    }

    
    public void SpawnObjectCruiser(){
        targetPosition = GetRandomPosition();
        Instantiate(Cruiser, targetPosition, transform.rotation);
        Level1Storage.CruiserCount ++;
        Level1Storage.CruiserCountAlive ++;
    }
    
    public void SpawnObjectCarrier(){
        targetPosition = GetRandomPosition();
        Instantiate(Carrier, targetPosition, transform.rotation);
        Level1Storage.CarrierCount ++;
        Level1Storage.CarrierCountAlive ++;
    }

    
    public void SpawnObjectSupporter(){
        targetPosition = GetRandomPosition();
        Instantiate(Supporter, targetPosition, transform.rotation);
        Level1Storage.SupporterCount ++;
        Level1Storage.SupporterCountAlive ++;
    }
    
    Vector2 GetRandomPosition() {
        float randomX = Random.Range(-3, 3);
        float randomY = Random.Range(10, 15);
        return new Vector2(randomX, randomY);
    }
}
