using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freighter : MonoBehaviour
{ 
    public float startingX = 18;
    public float speed;
    public float maxHealth;
    public int sprite = 0;

    public Enemy myEnemy;

    public SpriteRenderer spriteRenderer;
    public Sprite damagedOne;
    public Sprite damagedTwo;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(startingX, 0, 0);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 0)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (sprite == 1 && myEnemy.health < maxHealth * 1 / 3)
        {
            spriteRenderer.sprite = damagedTwo;
            sprite = 2;
        }
        else if (sprite == 0 && myEnemy.health < maxHealth * 2 / 3)
        {
            spriteRenderer.sprite = damagedOne;
            sprite = 1;
        }
    }
}
