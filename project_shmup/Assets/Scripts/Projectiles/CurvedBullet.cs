using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : Projectile
{
    public float circleSpeed = 1;
    public float circleSize = 0;
    public float circleGrowSpeed = 0.1f;
    Vector3 move;
    float iteration;
    float frames = 2400;


    void Start()
    {
        iteration = 0;
    }

    void Update()
    {
        //// big brain polar coordinate vector calculations for curvature //////////////
        move = Vector3.zero;
        move.x = Mathf.Sin(iteration * circleSpeed) * circleSize;
        move.y = -1 * Mathf.Cos(iteration * circleSpeed) * circleSize;
        circleSize += circleGrowSpeed;
        iteration += 6.283f / frames;
        if (iteration >= 6.283)
        {
            iteration = 0;
        }
    }
    
    void FixedUpdate()
    {
        CheckBounds();
        Vector3 increment = move * speed * Time.deltaTime;
        Vector3 after = transform.position + increment;
        transform.position += move * Time.deltaTime;

        // = = = ALTERNATIVE CURVING BULLET = = =
        // public float rotateSpeed;
        //transform.position += transform.up * speed * Time.deltaTime;
        //transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
