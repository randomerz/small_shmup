using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemySpawner : MonoBehaviour
{
    public GameObject zygote;
    public GameObject spawnPoint;
    public float fireRate;
    public float delay;
    private float timeTillNextShot;

    void Start()
    {
        timeTillNextShot = delay;
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
        Instantiate(zygote, spawnPoint.transform.position, Quaternion.identity);
    }
}
