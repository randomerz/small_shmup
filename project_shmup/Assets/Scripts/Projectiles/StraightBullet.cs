using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StraightBullet : Projectile
{

    public float topBound = 9;
    public float rightBound = 16;
    public float leftBound = -16;
    public float bottomBound = -9;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        if (transform.position.x > rightBound || transform.position.x < leftBound || transform.position.y > topBound || transform.position.y < bottomBound)
        {
            Destroy(transform.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        
        if(collision.gameObject.tag.Equals("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
                player.TakeLife();
            Destroy(gameObject);
        }
        
    }
}
