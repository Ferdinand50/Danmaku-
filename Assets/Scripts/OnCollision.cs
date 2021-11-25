using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public int healthPoints ;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 3;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
        healthPoints = healthPoints - 1;
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
