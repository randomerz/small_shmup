using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedBullet : Projectile
{
    // Start is called before the first frame update
    public float topBound;
    public float rightBound;
    public float leftBound;
    public float bottomBound;
    public float circleSpeed = 1;
    public float circleSize = 0;
    public float circleGrowSpeed = 0.1f;
    Vector3 move;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;
        move.x = Mathf.Sin(Time.time * circleSpeed) * circleSize;
        move.y = Mathf.Cos(Time.time * circleSpeed) * circleSize;
        circleSize += circleGrowSpeed;
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
}
