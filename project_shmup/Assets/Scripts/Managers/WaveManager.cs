using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] waves;
    public int currentWave;
    public bool infinite = false;
    

    void Start()
    {
        SpawnNextWave();

        // check
        foreach (GameObject g in waves)
        {
            if (g.GetComponent<EnemyWave>() == null)
                Debug.LogWarning("Game Object in WaveManager doesn't have an 'EnemyWave' component!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNextWave()
    {
        if (currentWave < waves.Length)
            Instantiate(waves[currentWave++], new Vector3(0, 0, 0), Quaternion.identity, transform);
        else
        {
            if (infinite)
            {
                Instantiate(waves[0], transform);
                currentWave = 1;
            }
            else
                StageComplete();
        }
    }

    public List<Enemy> GetEnemies()
    {
        // loop through waves and check if they arent null
        // NOT SURE it should be i < currentWave or i <= currentWave
        List<Enemy> e = new List<Enemy>();
        for (int i = 0; i < currentWave; i++)
            if (waves[i] != null && waves[i].GetComponent<EnemyWave>())
                foreach (Enemy j in waves[i].GetComponent<EnemyWave>().enemies)
                    e.Add(j);
        return e;
    }

    public void StageComplete()
    {
        Debug.Log("Stage Complete!");
    }
}
