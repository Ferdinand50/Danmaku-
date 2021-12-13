using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariableStorage : MonoBehaviour
{

    public static int globalVariable;
    public static int playerHealth;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
