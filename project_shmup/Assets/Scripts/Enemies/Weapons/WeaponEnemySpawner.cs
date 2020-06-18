using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemySpawner : MonoBehaviour
{
    public GameObject zygote;
    public Enemy parentEnemy;
    public GameObject spawnPoint;
    public float fireRate;
    public float delay;
    private float timeTillNextShot;

    void Start()
    {
        timeTillNextShot = delay;
        if (parentEnemy == null)
            parentEnemy = GetComponent<Enemy>();
    }
    
    void Update()
    {
        if (timeTillNextShot <= 0)
        {
            Shoot();
            timeTillNextShot = fireRate;
        }

        timeTillNextShot -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject g = Instantiate(zygote, spawnPoint.transform.position, Quaternion.identity);
        if (parentEnemy.wave != null)
        {
            parentEnemy.wave.AddEnemyToWave(g.GetComponent<Enemy>());
            g.GetComponent<Enemy>().wave = parentEnemy.wave;
        }
        else
            Debug.LogWarning("EnemyWave does not exist");
    }
}
