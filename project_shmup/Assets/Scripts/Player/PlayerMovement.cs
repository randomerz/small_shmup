using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12.0f; // player speed
    public Vector3 move; // directional vector
    bool holdingTwoHori = false; // checks if the player is holding both horizontal directions
    bool holdingTwoVert = false; // ^ for vertical
    public GameObject shipFocus;
    public float leftBound;
    public float rightBound;
    public float topBound;
    public float bottomBound;
    public float focusModifier;
    public bool isFocused;

    public bool canMove;
    

    // Controls: arrows for normal movement
    // Z and X for bomb and shoot
    void Start()
    {
        shipFocus.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // player movement calculations start here (p much near perfect movement, works better on WASD than arrow keys for some reason) ////////////////////////////////////////////////////////
        Vector3 prev = move;
        move = Vector3.zero;
        bool leftPressed = false;
        bool rightPressed = false;
        bool upPressed = false;
        bool downPressed = false;

        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                leftPressed = true;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rightPressed = true;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                upPressed = true;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                downPressed = true;
            }
            if (leftPressed && rightPressed)
            {
                if (holdingTwoHori)
                {
                    move.x = prev.x;
                }
                else
                {
                    move.x = prev.x * -1;
                    holdingTwoHori = true;
                }
            }
            else
            {
                holdingTwoHori = false;
                if (leftPressed)
                {
                    move.x = -1;
                }
                if (rightPressed)
                {
                    move.x = 1;
                }
            }
            if (upPressed && downPressed)
            {
                if (holdingTwoVert)
                {
                    move.y = prev.y;
                }
                else
                {
                    move.y = prev.y * -1;
                    holdingTwoVert = true;
                }
            }
            else
            {
                holdingTwoVert = false;
                if (downPressed)
                {
                    move.y = -1;
                }
                if (upPressed)
                {
                    move.y = 1;
                }
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                move = move * focusModifier;
                isFocused = true;
                shipFocus.SetActive(true);
            }
            else
            {
                isFocused = false;
                shipFocus.SetActive(false);
            }
            // player movement calculations end here ////////////////////////////////////////////////////////
        }
    }
    
    void FixedUpdate()
    {
        // player movement executed ////////////////////////////////////////////////////////
        if (move.magnitude == 0)
            return;
        Vector3 increment = move * speed * Time.deltaTime;
        increment /= move.magnitude;
        if (isFocused)
            increment *= focusModifier;
        Vector3 after = transform.position + increment;
        // player object bounds  ////////////////////////////////////////////////////////
        if (after.x < leftBound)
        {
            increment.x -= after.x - leftBound;
        }
        if (after.x > rightBound)
        {
            increment.x -= after.x - rightBound;
        }
        if (after.y < bottomBound)
        {
            increment.y -= after.y - bottomBound;
        }
        if (after.y > topBound)
        {
            increment.y -= after.y - topBound;
        }
        transform.position += increment;
    }

    /*void OnTriggerEnter2D(Collider2D hitInfo) // when the bullet collides with an enemy/object
    {
        if (hitInfo.gameObject.tag.Equals("Enemy"))
        {
            PlayerHealth player;
            Enemy enemy = hitInfo.GetComponent<Enemy>(); // stores the collidee as an enemy
            if (enemy != null) // if it actually collides with an enemy
            { // enemy takes damage
                player.TakeLife();
            }

            //Instantiate(impactEffect, transform.position, transform.rotation); // similar to deathEffect, if we want an animation for impact
        }
    }*/
}
