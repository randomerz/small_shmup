using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Projectile
{
    void Start()
    {
        //rb.velocity = transform.up * speed; // makes the bullet move
        projManager = GameObject.Find("Main Camera").GetComponent<ProjectileManager>();
    }

    void FixedUpdate()
    {
        CheckBounds();
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) // when the bullet collides with an enemy/object
    {
        if (hitInfo.gameObject.tag.Equals("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>(); // stores the collidee as an enemy
            if (enemy != null) // if it actually collides with an enemy
            { // enemy takes damage
                enemy.TakeDamage();
            }

            //Instantiate(impactEffect, transform.position, transform.rotation); // similar to deathEffect, if we want an animation for impact

            RemoveBullet();
        }
        else if (hitInfo.gameObject.tag.Equals("Boss"))
        {
            BossManager boss = hitInfo.GetComponent<BossManager>();
            if (boss!= null)
            {
                boss.TakeDamage();
            }
        }
    }

    public new void CheckBounds()
    {
        if (deleteIfOutOfBounds && (transform.position.x > rightBound + boundsOffset || transform.position.x < leftBound - boundsOffset || transform.position.y > topBound + boundsOffset || transform.position.y < bottomBound - boundsOffset))
        {
            RemoveBullet();
        }
    }

    public new void RemoveBullet()
    {
        if (projManager != null)
        {
            projManager.RemovePlayerBullet(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
