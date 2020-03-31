using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fodder : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }
}
