using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(coll.gameObject);
            GlobalVariableStorage.score = GlobalVariableStorage.score + 10;
        }
        Destroy(gameObject);
        
    }
}
