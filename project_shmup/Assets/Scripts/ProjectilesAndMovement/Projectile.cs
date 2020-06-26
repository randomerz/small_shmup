using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public ProjectileManager projManager;
    public float leftBound = -5.0625f;
    public float rightBound = 5.0625f;
    public float topBound = 9;
    public float bottomBound = -9;
    public float boundsOffset = 2;
    public bool deleteIfOutOfBounds = true;
    public float speed;

    //public GameObject impactEffect; // if we want an impact effect

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        projManager = camera.GetComponent<ProjectileManager>();
        Debug.Log(projManager);
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
            if (gameObject.tag.Equals("SpecialBullet"))
            {

            }
            else
            {
                RemoveBullet();
            }
            //Instantiate(impactEffect, transform.position, transform.rotation); // similar to deathEffect, if we want an animation for impact
        }
    }

    public void CheckBounds()
    {
        if (deleteIfOutOfBounds && (transform.position.x > rightBound + boundsOffset || transform.position.x < leftBound - boundsOffset || transform.position.y > topBound + boundsOffset || transform.position.y < bottomBound - boundsOffset))
        {
            RemoveBullet();
        }
    }

    public void RemoveBullet()
    {
        if (projManager != null)
        {
            projManager.RemoveEnemyBullet(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

