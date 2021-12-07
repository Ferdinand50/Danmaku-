using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public int healthPoints;

    void Start()
    {


    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "playerBullet")
        {
            Destroy(coll.gameObject);
            healthPoints = healthPoints - 1;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (healthPoints == 0)
        {
            Destroy(gameObject);
        }
    }
}
