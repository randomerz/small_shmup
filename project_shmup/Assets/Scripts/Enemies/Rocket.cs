using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class Rocket : MonoBehaviour
{
    public float speed;
    public float rspeed;

    private Transform player;
    private float rotate;
    private float a;
    private float movetimer = .05f;
    private float cycle = 0f;
    private Vector2 x;
    private float hyp;
    private double e;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (cycle >= movetimer)
        {
            cycle = 0f;
            rb.angularVelocity = FindAngle() * rspeed;
            rb.velocity = transform.up * speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        cycle += Time.deltaTime;
    }
    float FindAngle()
    {
        /*x = transform.position.x - player.transform.position.x;
        hyp = Vector3.Distance(transform.position, player.transform.position);
        e = (180 / Math.PI) * Math.Asin((transform.position.x - player.transform.position.x) / hyp);
        UnityEngine.Debug.Log(e);
        UnityEngine.Debug.Log(transform.rotation.eulerAngles.z);
        if (transform.position.y - player.transform.position.y > 0)
        {
            e = 180 - e;
        }   
        return (float)((e - transform.rotation.eulerAngles.z) / 6);*/
        //x = new Vector3((float)Math.Cos((Math.PI / 180) * transform.rotation.eulerAngles.z), (float)Math.Sin((Math.PI / 180) * transform.rotation.eulerAngles.z));
        //UnityEngine.Debug.Log((float)Vector3.Angle(v, player.transform.position - transform.position));
        if(Vector3.Cross(transform.up, player.transform.position - transform.position).z < 0)
        {
            return -(float)Vector3.Angle(transform.up, player.transform.position - transform.position);
        }
        else
        {
            return (float)Vector3.Angle(transform.up, player.transform.position - transform.position);
        }
        //return (float)Vector3.Angle(v, player.transform.position-transform.position);
        //The real version
        //return 0f;
        void OnTriggerEnter2D()
        {
            Destroy(gameObject);
        }
    }
}
