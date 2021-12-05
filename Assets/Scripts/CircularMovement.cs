using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates a Rotation around the Rotation Center
// rotation Center has to be created (empty Gameobject)
// in script rotationCenter has to be connected with the script
public class CircularMovement : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
     float rotationRadius = 6f, angularSpeed = -12f;
    [SerializeField]
     float posX, posY, angle = 0f;
     float convert = 1f;


    // Update is called once per frame
    void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos (angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin (angle) * rotationRadius;
        transform.position = new Vector2 (posX, posY);
        angle = angle + convert*Time.deltaTime * angularSpeed;
        
        if (angle <= -3.14|| angle > 0)  {
        convert = -1*convert;
        }
            
        
    }
}
