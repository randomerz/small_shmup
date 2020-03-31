using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 12.0f; // player speed
    Vector3 move; // directional vector
    bool holdingTwoHori = false; // checks if the player is holding both horizontal directions
    bool holdingTwoVert = false; // ^ for vertical
    
    // Controls: arrows for normal movement
    // Z and X for bomb and shoot
    void Start()
    {
        
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
            if(holdingTwoHori)
            {
                move.x = prev.x;
            } else
            {
                move.x = prev.x * -1;
                holdingTwoHori = true;
            }
        } else
        {
            holdingTwoHori = false;
            if(leftPressed)
            {
                move.x = -1;
            }
            if(rightPressed)
            {
                move.x = 1;
            }
        }
        if (upPressed && downPressed)
        {
            if(holdingTwoVert)
            {
                move.y = prev.y;
            } else
            {
                move.y = prev.y * -1;
                holdingTwoVert = true;
            }
        } else
        {
            holdingTwoVert = false;
            if(downPressed)
            {
                move.y = -1;
            }
            if(upPressed)
            {
                move.y = 1;
            }
        }
        // player movement calculations end here ////////////////////////////////////////////////////////
    }
    
    void FixedUpdate()
    {
        // player movement executed ////////////////////////////////////////////////////////
        Vector3 increment = move * speed * Time.deltaTime;
        Vector3 after = transform.position + increment;
        // player object bounds  ////////////////////////////////////////////////////////
        if (after.x < -13)
        {
            increment.x -= after.x+13;
        }
        if (after.x > 13)
        {
            increment.x -= after.x-13;
        }
        if (after.y < -9)
        {
            increment.y -= after.y+9;
        }
        if (after.y > 9)
        {
            increment.y -= after.y-9;
        }
        transform.position += increment;
    }
}
