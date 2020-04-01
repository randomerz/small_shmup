using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fodder : Enemy
{
    public float leftBound = -13;
    public float rightBound = 13;
    public float topBound = 9;
    public float bottomBound = -9;
    //distance from anchor of object to outside of hitbox
    public float offset = 0.9f;
    //1 is moving right, -1 is moving left
    //public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.position.x >= 15 || transform.position.x <= -15)
        {
            direction = direction * -1;
        }
        transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime * direction, 0, 0);
        */
        if (transform.position.y <= bottomBound + offset)
        {
            Die();
        }
        transform.position = transform.position + new Vector3(0, -1 * moveSpeed * Time.deltaTime, 0);
    }
}
