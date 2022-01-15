using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBossThree : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 20f;
    public float barycentreTwo = 0.01f;
    public float lifeTime = 20f;
    public Rigidbody2D rb;
    private float aimedPositionX;
    private float aimedPositionY;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyProjectile", lifeTime);

        aimedPositionX = GlobalVariableStorage.positionPlayer[0] +Random.Range(0, 4f);
        aimedPositionY = GlobalVariableStorage.positionPlayer[1] +Random.Range(0, 4f);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = rb.position[0] - aimedPositionX;
        float deltaY = rb.position[1] - aimedPositionY;
        float norm = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);

        rb.velocity = new Vector2(-deltaX / norm * speed * barycentreTwo + rb.velocity[0] * (1f - barycentreTwo), -deltaY / norm * speed * barycentreTwo + rb.velocity[1] * (1f - barycentreTwo));
        if (GlobalVariableStorage.BossHP <= 0)
        {
            DestroyProjectile();
        }
    }
}
