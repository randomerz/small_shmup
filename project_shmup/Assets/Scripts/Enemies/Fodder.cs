using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fodder : Enemy
{
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 15 || transform.position.x <= -15)
        {
            direction = direction * -1;
        }
        transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime * direction, 0, 0);
    }
}
