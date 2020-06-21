using UnityEngine;
using System;

public class Rocket : MonoBehaviour
{
    public GameObject player;
    private float rotate;
    private float a;
    private float movetimer = .05f;
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
        transform.position = new Vector3((transform.position.x + (float)Math.Sin(180 - transform.rotation.eulerAngles.z))/5, (transform.position.y + (float)Math.Cos(180 - transform.rotation.eulerAngles.z))/5,0);
    }
    public float FindAngle()
    {
        var y = transform.position.y - player.transform.position.y;
        var e = (180 / Math.PI) * Math.Atan((transform.position.x - player.transform.position.x) / y);
        UnityEngine.Debug.Log(e);
        return (float)((180-e - transform.rotation.eulerAngles.z) / 6);
    }
}
