using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject playerBullet;
    public float fireRate = 0.1f;
    public float timeSinceLastShot = 0.1f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot > fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                Shoot();
                timeSinceLastShot = 0;
            }
        }
    }

    void Shoot() // shoots ;)
    {
        Instantiate(playerBullet, firePoint.position, firePoint.rotation); // creates a bullet at firepoint
    }
}
