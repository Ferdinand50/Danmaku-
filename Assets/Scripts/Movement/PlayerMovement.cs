using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     // Start is called before the first frame update
   
    public float speed = 100f;
    private Vector2 targetPosition;
    void Start()
    {
        
        targetPosition = new Vector2(0.0f, -3.0f);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Input.mousePosition;
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(targetPosition.x, targetPosition.y, 0.0f));
        }
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        GlobalVariableStorage.positionPlayer = this.transform.position;
        //this.transform.position = targetPosition;



    }
}