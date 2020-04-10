using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;

    // THESE VARIABLES ARE DEPRECIATED AND WILL BE REMOVED
    public float moveSpeed;
    public float moveSpeedSide;
    public Projectile bullet;

    private EnemyWave wave;

    //public GameObject deathEffect; // we can use this to make a death effect when he explodes

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent != null)
            wave = transform.parent.GetComponent<EnemyWave>();
    }
    


    public void TakeDamage()
    {
        health -= 1; // subtract damage from health points

        if (health <= 0) // if the enemy runs out of health
        {
            Die(); // die :^)
        }
    }

    public void Die()
    {
        if (wave != null)
            wave.RemoveEnemy(this);
        // Instantiate(deathEffect, transform.position, Quaternion.identity); // see above
        Destroy(gameObject); // remove the enemy when he die
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
