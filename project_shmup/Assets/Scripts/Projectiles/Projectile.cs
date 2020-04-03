using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    public string path;
    public float damage;
    // Start is called before the first frame update
    void Start(float s, string p, float d)
    {
        speed = s;
        path = p;
        damage = d;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

