﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightB : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
