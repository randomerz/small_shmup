using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHearts;
    public float maxHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;

    // Start is called before the first frame update
    void Start()
    {
        DisplayHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeLife()
    {
        if (currentHearts >= 1)
        {
            currentHearts -= 1;
            DisplayHP(); // change the hp on the screen
            Debug.Log("Life lost.");
            // Instantiate( deathEffect, transform.position, Quaternion.identity); // death effect for player.
            if (currentHearts <= 0)
            {
                Die();
            }
        }

    }

    public void DisplayHP() // updates hp display 
    {
        for(int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = brokenHeart;
            }
        }
    }

    void Die()
    {
        //pull a game over//
        Debug.Log("You died.");

    }
}
