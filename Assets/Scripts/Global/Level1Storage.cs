using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Storage : MonoBehaviour
{   
    public static int FregatesCount;
    public static int CruiserCount;
    public static int FighterCount;
    public static int CarrierCount;
    public static int BossCount;
    public static int SupporterCount;



    public static int FregatesCountDead;
    public static int CruiserCountDead;
    public static int FighterCountDead;
    public static int CarrierCountDead;
    public static int BossCountDead;
    public static int SupporterCountDead;


    public static int FregatesCountAlive;
    public static int CruiserCountAlive;
    public static int FighterCountAlive;
    public static int CarrierCountAlive;
    public static int BossCountAlive;
    public static int SupporterCountAlive;
    void Start()
    {
        FregatesCount = 0;
        CruiserCount = 0;
        FighterCount = 0;
        CarrierCount = 0;
        BossCount = 0;
        SupporterCount = 0;

        FregatesCountDead = 0;
        CruiserCountDead = 0;
        FighterCountDead = 0;
        CarrierCountDead = 0;
        BossCountDead = 0;
        SupporterCountDead = 0;

        FregatesCountAlive = 0;
        CruiserCountAlive = 0;
        FighterCountAlive = 0;
        CarrierCountAlive = 0;
        BossCountAlive = 0;
        SupporterCountAlive = 0;
    }

}
