using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai_movement : MonoBehaviour
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    float roation;

    Vector2 targetPosition;


    public float speed;

    public float doublespeed;
    public float tempspeed;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();
        tempspeed = speed;
        doublespeed = 2 * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        } else {
            targetPosition = GetRandomPosition();
        }


        //doubles speed if outside of box
        if (transform.position.y > maxY) {
            speed = doublespeed;
        } else {
            speed = tempspeed;
        }
    }


    Vector2 GetRandomPosition() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }


}
