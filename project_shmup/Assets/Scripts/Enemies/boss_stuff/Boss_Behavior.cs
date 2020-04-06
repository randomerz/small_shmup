﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Boss_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    //boss is set at 16 pixels per unit so 1/16 for firing
    public float leftBound = -13;
    public float rightBound = 13;
    public float topBound = 9;
    public float bottomBound = -9;
    public float shift = 2.0f;
    public float cycle;
    public Vector3[] l;
    public bool b;
    private System.Random rand;

    void Start()
    {
        cycle = 0;
        l = new Vector3[4];
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        cycle += Time.deltaTime;
        if(cycle >= shift)
        {
            b = GeneratePos();
            while (b != true)
            {
                b = GeneratePos();
            }
            cycle = 0;
        }
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
        UnityEngine.Debug.Log(l[0]);
        for (var i = 0; i < 4; ++i)
        {
            if (l[i].x > leftBound && l[i].x < rightBound && l[i].y < topBound && l[i].y > bottomBound)
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
}