using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public float lifetime = 2;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        //Invoke("DestroyProjectile", lifettime);

    }

    void DestroyProjectile() {
        Destroy(gameObject);
        da
        
    }

    // Update is called once per frame

}
