using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float score;

    public EnemyWave wave;
    private ScoreManager scoreManager;
    
    public float tempHealth = 0;

    private bool strobing;
    private const string SHADER_COLOR_NAME = "_Color";
    private SpriteRenderer sprite;
    private Material material;

    //public GameObject deathEffect; // we can use this to make a death effect when he explodes

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent != null)
            wave = transform.parent.GetComponent<EnemyWave>();
        scoreManager = GameObject.Find("Main Camera").GetComponent<ScoreManager>();
        sprite = GetComponent<SpriteRenderer>();
        material = sprite.material;
    }
    

    public void TakeDamage()
    {
        if (tempHealth > 0)
        {
            tempHealth -= 1;
        }
        else
        {
            health -= 1; // subtract damage from health points
            if (health <= 0) // if the enemy runs out of health
            {
                Die(); // die :^)
            }
            else
            {
                StrobeColor(1, Color.black);
            }
        }
    }

    public void DestroyShield()
    {

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

    // code daniel copy pasted 
    public void StrobeColor(int _strobeCount, Color _toStrobe)
    {
        if (strobing)
            return;

        strobing = true;
        
        Color oldColor = sprite.color;

        StartCoroutine(StrobeColorHelper(0, ((_strobeCount * 2) - 1), oldColor, _toStrobe));
    }

    public void StrobeAlpha(int _strobeCount, float a)
    {
        Color toStrobe = new Color(sprite.color.r, sprite.color.b, sprite.color.g, a);
        StrobeColor(_strobeCount, toStrobe);
    }

    private IEnumerator StrobeColorHelper(int _i, int _stopAt, Color _color, Color _toStrobe)
    {
        if (_i <= _stopAt)
        {
            if (_i % 2 == 0)
                material.SetColor(SHADER_COLOR_NAME, _toStrobe);
            else
                material.SetColor(SHADER_COLOR_NAME, _color);

            yield return new WaitForSeconds(0.05f);
            StartCoroutine(StrobeColorHelper((_i + 1), _stopAt, _color, _toStrobe));
        }
        else
        {
            strobing = false;
        }
    }



    void Update()
    {
        
    }
}
