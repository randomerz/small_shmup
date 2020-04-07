using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float spawnRate = 0.3f;
    public float timeSinceWave;
    public float enemyAmount = 5;
    public float enemySeparation = 2.5f;

    public GameObject enemyPrefab;

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
        for (int i = 0; i < enemyAmount; i++)
        {
            Vector3 spawnPos = transform.position + new Vector3(enemySeparation * i, 0);
            // spawns fodder in spawnpos as a child of gameobject enemyContainer
            Instantiate(enemyPrefab, spawnPos, transform.rotation, enemyPrefab.transform);
        }
    }
}
