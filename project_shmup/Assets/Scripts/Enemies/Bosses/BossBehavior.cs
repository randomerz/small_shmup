﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //boss is set at 16 pixels per unit so 1/16 for firing
    public GameObject player;
    public GameObject missile;
    public float leftBound = -13;
    public float rightBound = 13;
    public float topBound = 9;
    public float bottomBound = -3;
    public float shift = 2.0f;
    public float cycle;

    private Vector3[] l;
    private bool b;
    private Dictionary<GameObject, Vector3[]> firePoints;
    private float prevRotate = 0;
    private System.Random rand;

    void Start()
    {
        firePoints = new Dictionary<GameObject, Vector3[]>();
        cycle = 0;
        l = new Vector3[4];
        rand = new System.Random();
    }
    // Update is called once per frame
    //Phase 1 slower teleportation with targeted shots
    //Phase 2 fast teleportation with missiles
    //Phase 3 Beam of death
    public void Teleport()
    {
        //GameObject player = GameObject.Find("Player");
        b = GeneratePos();
        while (b != true)
        {
            b = GeneratePos();
        }
        transform.Rotate(0f, 0f, -prevRotate+FindAngle());
        //Vector3[] a = { transform.position, transform.position + new Vector3(0, 1, 0) };
        //firePoints.Add(bullet, a);
        //Shoot(bullet);
        //firePoints.Remove(bullet);
    }
    public void Missile()
    {
        Instantiate(missile, transform.position, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 180)));
    }
    public bool GeneratePos()
    {
        float hshift = (Math.Abs(leftBound) + Math.Abs(rightBound)) * (float)rand.NextDouble(); //horizontal shift
        float vshift = (Math.Abs(topBound) + Math.Abs(bottomBound)) * (float)rand.NextDouble(); //vertical shift
        Array.Clear(l, 0, l.Length);
        l[0] = (transform.position + new Vector3(hshift, vshift, 0));
        l[1] = (transform.position + new Vector3(-hshift, vshift, 0));
        l[2] = (transform.position + new Vector3(hshift, -vshift, 0));
        l[3] = (transform.position + new Vector3(-hshift, -vshift, 0));
        Ruffle(l);
        for (var i = 0; i < 4; ++i)
        {
            if (l[i].x > leftBound && l[i].x < rightBound && l[i].y < topBound && l[i].y > bottomBound && (l[i] - player.transform.position).magnitude > 2)
            {
                transform.position = l[i];
                return true;
            }
        }
        return false;
    }
    public void Ruffle(Vector3[] ts)
    {
        var count = ts.Length;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
    public float FindAngle()
    {
        var y = transform.position.y - player.transform.position.y;
        var e = (180/Math.PI)*Math.Atan((transform.position.x - player.transform.position.x) / y);
        if(y<0)
        {
            e += 180d;
        }
        prevRotate = -(float)e;
        return prevRotate;
    }
}