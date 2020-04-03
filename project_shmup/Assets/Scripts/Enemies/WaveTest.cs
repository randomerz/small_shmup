﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTest : MonoBehaviour
{
    public float spawnRate = 0.3f;
    public float timeSinceWave;
    public float enemyAmount = 5;
    public float enemySeparation = 2.5f;

    public GameObject fodder1;

    public GameObject enemyContainer;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceWave = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceWave += Time.deltaTime;
        if (timeSinceWave > spawnRate)
        {
            SpawnWave();
            timeSinceWave = 0;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(enemySeparation * i, 0);
            // spawns fodder in spawnpos as a child of gameobject enemyContainer
            Instantiate(fodder1, spawnPos, transform.rotation, enemyContainer.transform);
        }
    }
}
