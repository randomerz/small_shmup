using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodderWeapon : MonoBehaviour
{

    public float offset = -1.01f;
    public GameObject enemyBullet;
    public float fireRate = 0.5f;
    public float timeSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShot = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot > fireRate)
        {
            Shoot();
            timeSinceLastShot = 0;
        }
    }

    void Shoot()
    {
        var rot = transform.rotation;
        rot.z += 180;
        Instantiate(enemyBullet, transform.position + new Vector3(0, offset, 0), rot);
    }
}
