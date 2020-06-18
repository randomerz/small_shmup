using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratedChasePoints : MonoBehaviour
{
    public float speed = 3;
    public float accelerationSpeed = 5;
    public float dragFactor = 0.2f;
    private Vector3 v;
    private Vector3 a;

    public List<Vector3> points = new List<Vector3>();
    public float minDistToPoint = 2f;
    public float pointsLeftBound = -7;
    public float pointsRightBound = 7;
    public float pointsTopBound = 7;
    public float pointsBottomBound = 0;
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
        if (points.Count == 0)
        {
            AddNewPointRandom();
        }
        a = Vector3.Normalize(points[0] - transform.position);

        // physics
        float theta = Mathf.Atan2(v.y, v.x);
        float d = dragFactor * Mathf.Pow(v.x * v.x + v.y * v.y, .5f);
        Vector3 dv = d * new Vector3(Mathf.Cos(theta), Mathf.Sin(theta));

        a -= dv;

        transform.position += new Vector3(v.x, v.y) * speed * Time.deltaTime;
        v += a * speed * Time.deltaTime;

        a += dv;

        // bounce off walls code
        //float r = width / 2;
        //if (x < 0) { x = 0; v.x = -v.x * .5f; v.y *= .5f; }
        //if (y < 0) { y = 0; v.y = -v.y * .5f; v.x *= .5f; }
        //if (x + width > canvas.getWidth()) { x = canvas.getWidth() - width; v.x = -v.x * .5f; v.y *= .5f; }
        //if (y + height > canvas.getHeight()) { y = canvas.getHeight() - height; v.y = -v.y * .5f; v.x *= .5f; }

        // restrained in box
        //if (transform.position.x < restraintLeftBound)   { transform.position = new Vector2(restraintLeftBound,   transform.position.y); v.x = 0; }
        //if (transform.position.y < restraintBottomBound) { transform.position = new Vector2(transform.position.x, restraintBottomBound); v.y = 0; }
        //if (transform.position.x > restraintRightBound)  { transform.position = new Vector2(restraintRightBound,  transform.position.y); v.x = 0; }
        //if (transform.position.y > restraintTopBound)    { transform.position = new Vector2(transform.position.x,    restraintTopBound); v.y = 0; }
        if (transform.position.x < restraintLeftBound)   { v.x = Mathf.Max(0, v.x); }
        if (transform.position.y < restraintBottomBound) { v.y = Mathf.Max(0, v.y); }
        if (transform.position.x > restraintRightBound)  { v.x = Mathf.Min(0, v.x); }
        if (transform.position.y > restraintTopBound)    { v.y = Mathf.Min(0, v.y); }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg - 90));
        if ((points[0] - transform.position).magnitude < minDistToPoint)
        {
            points.RemoveAt(0);
        }
    }

    private void AddNewPointRandom()
    {
        points.Add(new Vector3(Random.Range(pointsLeftBound, pointsRightBound), Random.Range(pointsBottomBound, pointsTopBound)));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (points.Count >= 1)
            Gizmos.DrawSphere(points[0], 0.2f);
        Gizmos.color = Color.yellow;
        if (points.Count >= 2)
            for (int i = 1; i < points.Count; i++)
                Gizmos.DrawSphere(points[i], 0.2f);
    }
}
