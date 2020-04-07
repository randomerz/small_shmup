using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderMovement : Enemy
{ 
    public float leftBound = -13;
    public float rightBound = 13;
    public float topBound = 9;
    public float bottomBound = -9;
    //distance from anchor of object to outside of hitbox
    public float offset = -1.0f;
    //1 is moving right, -1 is moving left
    public int direction = 1;
    System.Random rand = new System.Random();
    public float timeSinceTurn = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rand.NextDouble() < .4 && timeSinceTurn > rand.NextDouble() + .5)
        {
            direction *= -1;
            timeSinceTurn = 0;
        }
        transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime * direction, 0, 0);
        timeSinceTurn += Time.deltaTime;
    }
}
