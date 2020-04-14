using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Enemy
{
    public float timeToExplosion = 5.0f;
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
        timeToExplosion -= Time.deltaTime;
        if (timeToExplosion <= 3.5)
        {
            Explode();
        }
    }

    void Explode()
    {
        animator.SetBool("explode", true);
    }
}
