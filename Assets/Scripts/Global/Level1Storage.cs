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

    void Start()
    {
        FregatesCount = 0;
        CruiserCount = 0;
        FighterCount = 0;
        CarrierCount = 0;
        BossCount = 0;
        SupporterCount = 0;
    }

}
