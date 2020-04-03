using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlsoCurvedBullet : Projectile
{
    public float rotateSpeed;

    public float topBound = 9;
    public float rightBound = 16;
    public float leftBound = -16;
    public float bottomBound = -9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        if (transform.position.x > rightBound || transform.position.x < leftBound || transform.position.y > topBound || transform.position.y < bottomBound)
        {
            Destroy(transform.gameObject);
        }
    }
}
