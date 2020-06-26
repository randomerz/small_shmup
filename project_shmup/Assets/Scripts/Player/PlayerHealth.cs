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

    public float timeSinceDmg = 0;
    private bool strobing;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DisplayHP();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDmg += Time.deltaTime;
    }


    public void TakeLife()
    {
        if (timeSinceDmg > 1.0)
        {
            timeSinceDmg = 0;
            if (currentHearts >= 1)
            {
                currentHearts -= 1;
                DisplayHP(); // change the hp on the screen
                Debug.Log("Life lost.");
                audioSource.Play();
                // Instantiate( deathEffect, transform.position, Quaternion.identity); // death effect for player.
                if (currentHearts <= 0)
                {
                    Die();
                }
                else
                {
                    StrobeAlpha(5, 0.5f);
                }
            }
        }
    }

    public void DisplayHP() // updates hp display 
    {
        for(int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                if (hearts[i] != null)
                    hearts[i].sprite = fullHeart;
            }
            else
            {
                if (hearts[i] != null)
                    hearts[i].sprite = brokenHeart;
            }
        }
    }

    void Die()
    {
        //pull a game over//
        Debug.Log("You died.");

    }

    public void StrobeColor(int _strobeCount, Color _toStrobe)
    {
        if (strobing)
            return;

        strobing = true;

        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        Color oldColor = mySprite.color;

        StartCoroutine(StrobeColorHelper(0, ((_strobeCount * 2) - 1), mySprite, oldColor, _toStrobe));

    }

    public void StrobeAlpha(int _strobeCount, float a)
    {
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        Color toStrobe = new Color(mySprite.color.r, mySprite.color.b, mySprite.color.g, a);
        StrobeColor(_strobeCount, toStrobe);
    }

    private IEnumerator StrobeColorHelper(int _i, int _stopAt, SpriteRenderer _mySprite, Color _color, Color _toStrobe)
    {
        if (_i <= _stopAt)
        {
            if (_i % 2 == 0)
                _mySprite.color = _toStrobe;
            else
                _mySprite.color = _color;

            yield return new WaitForSeconds(.2f);
            StartCoroutine(StrobeColorHelper((_i + 1), _stopAt, _mySprite, _color, _toStrobe));
        }
        else
        {
            strobing = false;
        }
    }
}
