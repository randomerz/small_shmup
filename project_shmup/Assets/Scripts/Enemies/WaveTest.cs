using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTest : MonoBehaviour
{
    public float spawnRate = 0.3f;
    public float timeSinceWave;
    public float enemyAmount = 5;
    public float enemySeparation = 2.5f;
    public GameObject fodder1;

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
            spawnWave();
            timeSinceWave = 0;
        }
    }

    void spawnWave()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(fodder1, transform.position + new Vector3(enemySeparation * i, 0, 0), transform.rotation);
        }
    }
}
