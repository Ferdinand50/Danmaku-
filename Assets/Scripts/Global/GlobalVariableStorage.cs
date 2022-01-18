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
<<<<<<< HEAD
    public static int BossMaxHP = 300;
=======
    public static int BossMaxHP = 2000;
>>>>>>> 89e14cf1f0857a7612a1fbe88f9af8e0c6d2646b
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
