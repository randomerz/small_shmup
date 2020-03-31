using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 12.0f; // player speed
    Vector3 move; // directional vector
    
    // Controls: arrows for normal movement
    // Z and X for bomb and shoot
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }
    
    void FixedUpdate()
    {
        transform.position += move * speed * Time.deltaTime; // basic player movement
    }
}
