using UnityEngine;
using System;

public class Rocket : MonoBehaviour
{
    public GameObject player;
    private float rotate;
    private float a;
    private float movetimer = .5f;
    private float cycle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        cycle += Time.deltaTime;
        if (cycle >= movetimer)
        {
            cycle = 0f;
            a = FindAngle();
            transform.Rotate(0f, 0f, a);
            Move();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move()
    {
        transform.position = new Vector3(transform.position.x + (float)Math.Sin(transform.rotation.eulerAngles.z), transform.position.y + (float)Math.Cos(transform.rotation.eulerAngles.z),0);
    }
    public float FindAngle()
    {
        UnityEngine.Debug.Log(transform.rotation.eulerAngles);
        var y = transform.position.y - player.transform.position.y;
        var e = (180 / Math.PI) * Math.Atan((transform.position.x - player.transform.position.x) / y);
        return (float)((-e - transform.rotation.eulerAngles.z) / 4);
    }
}
