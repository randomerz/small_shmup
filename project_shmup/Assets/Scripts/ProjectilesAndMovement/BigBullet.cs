using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{

    public float timeToExplosion = 6.0f;
    public float timeSinceExplosion = 0;
    private bool exploding = false;
    public Projectile projectile;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        timeToExplosion = timeToExplosion - 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToExplosion -= Time.deltaTime;
        if (timeToExplosion <= 0)
        {
            timeSinceExplosion += Time.deltaTime;
            if (timeSinceExplosion >= 0.5f)
            {
                projectile.RemoveBullet();
            }
            animator.SetBool("explode", true);
        }
    }
}
