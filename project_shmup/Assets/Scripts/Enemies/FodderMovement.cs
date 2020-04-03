using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderMovement : Enemy
{ 
    public float leftBound = -13;
    public float rightBound = 13;
    public float topBound = 9;
    public float bottomBound = -9;
    public float timeSinceTurn;
    public float turnRate = 1.0f;
    //distance from anchor of object to outside of hitbox
    public float offset = -1.0f;
    //1 is moving right, -1 is moving left
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTurn += Time.deltaTime;
        if (timeSinceTurn > turnRate)
        {
            direction = direction * -1;
            timeSinceTurn = 0;
        }
        
        if (transform.position.y <= bottomBound + offset)
        {
            Die();
        }
        transform.position = transform.position + new Vector3(moveSpeedSide * Time.deltaTime * direction, -1 * moveSpeed * Time.deltaTime, 0);
    }
}
