using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Enemy
{
    public float timeToExplosion = 5.0f;
    public float timeSinceExplosion = 0;
    public bool exploding = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (timeToExplosion < 3.5)
        {
            Debug.LogWarning("timeToExplosion cannot be less than 3.5.");
            timeToExplosion = 3.5f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (exploding == false)
        {
            timeToExplosion -= Time.deltaTime;
            if (timeToExplosion <= 3.5)
            {
                Explode();
                exploding = true;
            }
        }
        else
        {
            timeSinceExplosion += Time.deltaTime;
            if (timeSinceExplosion > 4.2)
            {
                Die();
            }
        }
    }

    void Explode()
    {
        animator.SetBool("explode", true);
    }
}
