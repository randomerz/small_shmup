using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : Projectile
{
    public float topBound;
    public float rightBound;
    public float leftBound;
    public float bottomBound;
    public float circleSpeed = 1;
    public float circleSize = 0;
    public float circleGrowSpeed = 0.1f;
    Vector3 move;
    float iteration;
    float frames = 2400;
    public Rigidbody rb;


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
        Vector3 increment = move * speed * Time.deltaTime;
        Vector3 after = transform.position + increment;
        // player object bounds  ////////////////////////////////////////////////////////
        if (after.x < leftBound || after.x > rightBound || after.y < bottomBound || after.y > topBound)
        {
            Destroy(transform.gameObject);
        }
        transform.position += move * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
                player.TakeLife();
            Destroy(gameObject);
        }

    }
}
