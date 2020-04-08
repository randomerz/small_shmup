using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public WaveManager waveManager;

    private bool waveCalled = false;

    // Conditions
    public bool conditionAllEnemiesDead = true;

    public bool conditionTimePassed = false;
    public float timeToWait = 1f;
    private float timePassed;

    void Start()
    {
        waveManager = GameObject.Find("Main Camera").GetComponent<WaveManager>();
        foreach (Enemy e in GetComponentsInChildren<Enemy>())
            enemies.Add(e);
    }
    
    void FixedUpdate()
    {
        timePassed += Time.deltaTime;
        if (conditionTimePassed && timePassed >= timeToWait)
            TrySpawnNextWave();
    }

    public void TrySpawnNextWave()
    {
        if (!waveCalled)
            waveManager.SpawnNextWave();
        waveCalled = true;
    }

    public void RemoveEnemy(Enemy e)
    {
        Destroy(e.gameObject);
        enemies.Remove(e);
        if (enemies.Count == 0)
        {
            if (conditionAllEnemiesDead)
                TrySpawnNextWave();
            RemoveWave();
        }
    }

    public void RemoveWave()
    {
        foreach (Enemy e in enemies)
            Destroy(e.gameObject);
        Destroy(gameObject);
    }
}
