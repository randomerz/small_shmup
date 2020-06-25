using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{

    public float timeToExplosion = 6.0f;
    private float timeSinceExplosion = 0;
    private bool exploding = false;
    public Projectile projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (exploding == false)
        {
            timeToExplosion -= Time.deltaTime;
            if (timeToExplosion <= 0)
            {
                projectile.RemoveBullet();
            }
        }
    }
}
