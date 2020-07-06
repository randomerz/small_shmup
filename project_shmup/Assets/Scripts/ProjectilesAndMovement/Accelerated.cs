using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerated : MonoBehaviour
{
    public Vector3 v;
    public Vector3 a;

    public float restraintLeftBound = -9;
    public float restraintRightBound = 9;
    public float restraintTopBound = 9;
    public float restraintBottomBound = -9;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // physics
        //float theta = Mathf.Atan2(v.y, v.x);
        //float d = dragFactor * Mathf.Pow(v.x * v.x + v.y * v.y, .5f);
        //Vector3 dv = d * new Vector3(Mathf.Cos(theta), Mathf.Sin(theta));

        //a -= dv;

        transform.position += v * Time.deltaTime;
        v += a * Time.deltaTime;
        
        if (transform.position.x < restraintLeftBound)   { v.x = Mathf.Max(0, v.x); }
        if (transform.position.y < restraintBottomBound) { v.y = Mathf.Max(0, v.y); }
        if (transform.position.x > restraintRightBound)  { v.x = Mathf.Min(0, v.x); }
        if (transform.position.y > restraintTopBound)    { v.y = Mathf.Min(0, v.y); }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + a);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + v);
    }
}
