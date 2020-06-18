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
    public float leftBound = -7;
    public float rightBound = 7;
    public float topBound = 7;
    public float bottomBound = 0;

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
        //float r = width / 2;
        //if (x < 0) { x = 0; v.x = -v.x * .5f; v.y *= .5f; }
        //if (y < 0) { y = 0; v.y = -v.y * .5f; v.x *= .5f; }
        //if (x + width > canvas.getWidth()) { x = canvas.getWidth() - width; v.x = -v.x * .5f; v.y *= .5f; }
        //if (y + height > canvas.getHeight()) { y = canvas.getHeight() - height; v.y = -v.y * .5f; v.x *= .5f; }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg - 90));
        if ((points[0] - transform.position).magnitude < minDistToPoint)
        {
            points.RemoveAt(0);
        }
    }

    private void AddNewPointRandom()
    {
        points.Add(new Vector3(Random.Range(leftBound, rightBound), Random.Range(bottomBound, topBound)));
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
