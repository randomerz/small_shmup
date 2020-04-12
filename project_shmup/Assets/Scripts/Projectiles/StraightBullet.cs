using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StraightBullet : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        projManager = GameObject.Find("Main Camera").GetComponent<ProjectileManager>();
        type = "straight_bullet";

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckBounds();
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
