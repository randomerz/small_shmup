using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject playerBullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() // shoots ;)
    {
        Instantiate(playerBullet, firePoint.position, firePoint.rotation); // creates a bullet at firepoint
    }
}
