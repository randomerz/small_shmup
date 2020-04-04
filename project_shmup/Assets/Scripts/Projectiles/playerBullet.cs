using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{
    public Rigidbody2D rb;

    //public GameObject impactEffect; // if we want an impact effect

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed; // makes the bullet move
    }

    void Update()
    {

    }

    void OnBecameInvisible() // when the bullet leaves the camera view
    {
        Destroy(gameObject); // delete bullet to free memory space
    }

    void OnTriggerEnter2D(Collider2D hitInfo) // when the bullet collides with an enemy/object
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>(); // stores the collidee as an enemy
        if (enemy != null) // if it actually collides with an enemy
        {
            enemy.TakeDamage(damage); // enemy takes damage
        }

        //Instantiate(impactEffect, transform.position, transform.rotation); // similar to deathEffect, if we want an animation for impact

        Destroy(gameObject); // deletes bullet
    }
}
