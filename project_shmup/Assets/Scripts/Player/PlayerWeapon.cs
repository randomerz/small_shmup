using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject playerBullet;
    public float fireRate = 0.1f;
    public float timeSinceLastShot = 0.1f;
    public float bombRate = 0;
    public float timeSinceLastBomb = 3f;
    private ProjectileManager bulletManager;
    public float currentBombs;
    public float maxBombs;
    public Image[] bombList;
    public Sprite bomb;

    void Start()
    {
        bulletManager = GameObject.Find("Main Camera").GetComponent<ProjectileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        timeSinceLastBomb += Time.deltaTime;

        if (timeSinceLastShot > fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
                timeSinceLastShot = 0;
            }
        }

        if (timeSinceLastBomb > bombRate)
        {
            if (Input.GetButton("Fire2"))
            {
                Debug.Log("bomb");
                Bomb();
                timeSinceLastBomb = 0;
            }
        }
    }

    void Shoot() // shoots ;)
    {
        if (bulletManager != null)
        {
            GameObject b = bulletManager.CreatePlayerBullet(playerBullet, firePoint).gameObject;
            Debug.Log(firePoint.position);
        }
        else
        {
            Instantiate(playerBullet, firePoint.position, firePoint.rotation); // creates a bullet at firepoint
        }
        
    }

    void Bomb() // does not actually make a bomb. it clears the screen of bullets and flashes white. **EPILEPSY WARNING!**
    {
        if (bulletManager != null)
        {
            bulletManager.ClearBullets();
            currentBombs--;
            DisplayBombs();
        }
        // flash screen 
    }

    public void DisplayBombs() // updates hp display 
    {
        for (int i = 0; i < maxBombs; i++)
        {
            if (i < currentBombs)
            {
                bombList[i].sprite = bomb;
            }
            else
            {
                bombList[i].sprite = null;
            }
        }
    }
}
