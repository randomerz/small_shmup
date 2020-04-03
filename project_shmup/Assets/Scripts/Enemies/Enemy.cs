using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float moveSpeed;
    public float moveSpeedSide;
    public Projectile bullet;
    //public GameObject deathEffect; // we can use this to make a death effect when he explodes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage (float damage)
    {
        health -= damage; // subtract damage from health points

        if (health <= 0) // if the enemy runs out of health
        {
            Die(); // die :^)
        }
    }

    public void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity); // see above
        Destroy(gameObject); // remove the enemy when he die
    }

    public void Shoot (float time, Projectile bullet)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
