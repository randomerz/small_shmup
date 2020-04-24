using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float score;

    private EnemyWave wave;
    private ScoreManager scoreManager;

    public GameObject shield;
    public bool isShielded = false;
    public float shieldHealth = 0;

    //public GameObject deathEffect; // we can use this to make a death effect when he explodes

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(isShielded);
        if (transform.parent != null)
            wave = transform.parent.GetComponent<EnemyWave>();
        scoreManager = GameObject.Find("Main Camera").GetComponent<ScoreManager>();
    }
    


    public void TakeDamage()
    {
        if (isShielded == true)
        {
            shieldHealth -= 1;
            if (shieldHealth == 0)
            {
                isShielded = false;
            }
        }
        else
        {
            health -= 1; // subtract damage from health points
            if (health <= 0) // if the enemy runs out of health
            {
                Die(); // die :^)
            }
        }
    }

    // Called when hp = 0
    public void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity); // see above
        if (wave != null)
            wave.RemoveEnemy(this);
        if (scoreManager != null)
            scoreManager.AddScore(score);
        else
            Debug.LogWarning("scoring shits not here");

        RemoveGameObject();
    }

    // called when enemy should be removed from the scene
    public void RemoveGameObject()
    {
        Destroy(gameObject); // remove the enemy when he die
    }


    
    void Update()
    {
        shield.SetActive(isShielded);
    }
}
