using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public float lifeTime = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
        Invoke("DestroyProjectile", lifeTime);



    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
    

    // Update is called once per frame

}