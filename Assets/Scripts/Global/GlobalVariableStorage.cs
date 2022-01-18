using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableStorage : MonoBehaviour
{

    public static int globalVariable;
    public static int playerHealth;
    public static int score;
    public static Vector2 positionPlayer;
    public static int BossHP;

    public static int BossMaxHP = 2000;

    // Start is called before the first frame update
    void Start()
    {
        
        playerHealth = 10;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
