using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    public string path;

    public ProjectileManager projManager;
    public bool deleteIfOutOfBounds = true;
    public float leftBound = 5.0625f;
    public float rightBound = 5.0625f;
    public float topBound = 9;
    public float bottomBound = -9;
    public float boundsOffset = 2;

    //public GameObject impactEffect; // if we want an impact effect

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        projManager = camera.GetComponent<ProjectileManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckBounds();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
                player.TakeLife();
            //Instantiate(impactEffect, transform.position, transform.rotation); // similar to deathEffect, if we want an animation for impact
            Destroy(gameObject);
        }
    }

    public void CheckBounds()
    {
        if (deleteIfOutOfBounds && (transform.position.x > rightBound + boundsOffset || transform.position.x < leftBound - boundsOffset || transform.position.y > topBound + boundsOffset || transform.position.y < bottomBound - boundsOffset))
        {
            if (projManager != null)
                projManager.RemoveEnemyBullet(this);
            else
                Destroy(gameObject);
        }
    }
}

