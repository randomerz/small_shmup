using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freighter : MonoBehaviour
{ 
    public float startingX = 18;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(startingX, 0, 0);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 0)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }
}
