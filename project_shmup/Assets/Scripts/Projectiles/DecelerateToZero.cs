using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecelerateToZero : Projectile
{
    public float acceleration;

    // requires distToTravel and timeToTake to be filled
    public bool useDistance = true;
    public float timeToTake;
    public float distToTravel;

    private float timeTaken = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // 2(x - vt) / t2
        if (timeToTake <= 0)
        {
            if (useDistance)
                Debug.LogWarning("Time to take not set, defaulting to 1 second!");
            timeToTake = 1;
        }
        if (speed == 0)
            speed = 1;
        // if dist doesnt reach or they are different signs
        if (useDistance && (Mathf.Abs(speed * timeToTake) < Mathf.Abs(distToTravel) || speed > 0 && distToTravel < 0 || speed < 0 && distToTravel > 0))
        {
            speed = distToTravel / timeToTake;
            Debug.LogWarning("Speed value not valid, defaulting to " + speed);
        }
        if (useDistance)
        {
            acceleration = 2 * (distToTravel - speed * timeToTake) / Mathf.Pow(timeToTake, 2);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckBounds();
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        timeTaken += Time.deltaTime;
        if (timeTaken >= timeToTake)
        {
            speed = acceleration = 0;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (timeToTake <= 0)
            timeToTake = 1;
        Gizmos.color = Color.red;
        if (!useDistance)
        {
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, speed * timeToTake + .5f * acceleration * timeToTake * timeToTake));
        }
        else if (useDistance)
        {
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, distToTravel));
        }
    }
}
