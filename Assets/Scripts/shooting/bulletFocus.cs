using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFocus : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float barycentreTwo;
    public float lifeTime;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame


    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
        Debug.Log(rb.position);
        float deltaX = rb.position[0] - GlobalVariableStorage.positionPlayer[0];
        float deltaY = rb.position[1] - GlobalVariableStorage.positionPlayer[1];
        float norm = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);

        rb.velocity = new Vector2 (-deltaX / norm *speed * barycentreTwo + rb.velocity[0] * (1f- barycentreTwo), -deltaY/norm * speed * barycentreTwo + rb.velocity[1] * (1f- barycentreTwo)) ;
        if (GlobalVariableStorage.BossHP <= 0)
        {
            DestroyProjectile();
        }
    }
}
