using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    public GameObject Fregate;
    public GameObject Cruiser;
    public GameObject Carrier;
    public GameObject Supporter;
    private AudioManager theAM;
    public AudioClip newTrack;
    Vector2 targetPosition;
    public float timeToSpawn;
    private float currentTimeToSpawn;

    //Insofar as I edited the spawning rules (depending on the current wave), are these values still useful ? Eliott
    private bool FrigateSpawned = true;
    private bool SupporterSpawned = true;
    private bool CarrierSpawned = true;
    private bool ReadyForBoss = false;
    private bool BossSpawned = true;
    private bool BossDead = false;

    // Updated spawning rules
    private bool Wave1Ok = false;
    private bool Wave2Ok = false;
    private bool Wave3Ok = false;
    private bool Wave4Ok = false;
    private bool Wave5Ok = false;
    private bool Wave6Ok = false;
    private bool Wave7Ok = false;
    private bool Wave8Ok = false;
    private bool Wave9Ok = false;

    void Start()
    {
        
        SpawnObjectFregate();
        SpawnObjectFregate();
        Wave1Ok = true;
        theAM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Level1Storage.TotalCountAlive == 0 & Wave1Ok & !Wave2Ok){
            SpawnObjectFregate();
            SpawnObjectFregate();
            Wave2Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave2Ok & !Wave3Ok)
        {
            SpawnObjectCruiser();
            Wave3Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave3Ok & !Wave4Ok)
        {
            SpawnObjectFregate();
            SpawnObjectFregate();
            Wave4Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave4Ok & !Wave5Ok)
        {
        SpawnObjectFregate();
        SpawnObjectFregate();
        SpawnObjectCruiser();
            Wave5Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave5Ok & !Wave6Ok)
        {
        SpawnObjectSupporter();
        SpawnObjectSupporter();
            Wave6Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave6Ok & !Wave7Ok) {
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        SpawnObjectSupporter();
        SpawnObjectSupporter();
            Wave7Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave7Ok & !Wave8Ok) {
            SpawnObjectCarrier();
            Wave8Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave8Ok & !Wave9Ok) {
            SpawnObjectSupporter();
            SpawnObjectSupporter();
            SpawnObjectCruiser();
            Wave9Ok = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & Wave9Ok & !ReadyForBoss) {
            SpawnObjectFregate();
            SpawnObjectSupporter();
            SpawnObjectCruiser();
            ReadyForBoss = true;
        }
        if(Level1Storage.TotalCountAlive == 0 & ReadyForBoss & BossSpawned ) {
        SpawnObjectBoss();
        BossSpawned = false;
        theAM.ChangeBGM(newTrack);
        }
        if(Level1Storage.BossCountDead == 1) {
        StartCoroutine(waiter());
        
        }
    }
    
    public void SpawnObjectBoss(){
        targetPosition = GetRandomPosition();
        Instantiate(Boss, transform.position, Boss.transform.rotation);
        Level1Storage.BossCount ++;
        Level1Storage.BossCountAlive ++;
        Level1Storage.TotalCountAlive++;
    }
    
    public void SpawnObjectFregate(){
        targetPosition = GetRandomPosition();
        Instantiate(Fregate, targetPosition, transform.rotation);
        Level1Storage.FregatesCount ++;
        Level1Storage.FregatesCountAlive ++;
        Level1Storage.TotalCountAlive++;
    }

    
    public void SpawnObjectCruiser(){
        targetPosition = GetRandomPosition();
        Instantiate(Cruiser, targetPosition, transform.rotation);
        Level1Storage.CruiserCount ++;
        Level1Storage.CruiserCountAlive ++;
        Level1Storage.TotalCountAlive++;
    }
    
    public void SpawnObjectCarrier(){
        targetPosition = GetRandomPosition();
        Instantiate(Carrier, targetPosition, transform.rotation);
        Level1Storage.CarrierCount ++;
        Level1Storage.CarrierCountAlive ++;
        Level1Storage.TotalCountAlive++;
    }

    
    public void SpawnObjectSupporter(){
        targetPosition = GetRandomPosition();
        Instantiate(Supporter, targetPosition, transform.rotation);
        Level1Storage.SupporterCount ++;
        Level1Storage.SupporterCountAlive ++;
        Level1Storage.TotalCountAlive++;
    }
    
    Vector2 GetRandomPosition() {
        float randomX = Random.Range(-3, 3);
        float randomY = Random.Range(10, 15);
        return new Vector2(randomX, randomY);
    }

    IEnumerator waiter()
{

    yield return new WaitForSeconds(4);
    SceneManager.LoadScene("Menu");

}
}

