using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotgun : MonoBehaviour
{
    public GameObject bullet;
    public int numBullets;
    public float spread; // degrees of total cone
    private ProjectileManager bulletManager;

    public float fireRate;
    private float timeSinceLastShot;

    public bool isAimedAtPlayerSimple;
    public bool isAimedAtPlayerPredictive;
    public PlayerMovement playerMovement;

    void Start()
    {
        bulletManager = GameObject.Find("Main Camera").GetComponent<ProjectileManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastShot >= fireRate)
        {
            Shoot();
            timeSinceLastShot = 0;
        }

        timeSinceLastShot += Time.deltaTime;
    }

    void Shoot()
    {
        float baseAngle = 0;
        float angleSlice = 0;
        if (numBullets != 1)
            angleSlice = spread / (numBullets - 1);

        if (isAimedAtPlayerPredictive)
        {
            // calculates time bullet will take to hit player with player moving @ its current speed + direction
            //baseAngle = 180;
            //needs to be updated with correct threshold
            if (playerMovement.speed > bullet.GetComponent<Projectile>().speed)
            {
                Debug.Log("WARNING: Player Move Speed too high for predictive aiming.");
                isAimedAtPlayerPredictive = false;
                isAimedAtPlayerSimple = true;
            }
            Vector3 playerPos = playerMovement.transform.position;
            float speed = playerMovement.speed;
            Vector3 rot = playerMovement.move;
            float tempAngle;
            Vector3 diff = playerPos - transform.position;
            //angle in radians between enemy and player
            float angle = Mathf.Atan2(diff.y, diff.x);
            //angle that player is pointed at
            float playerAngle = Mathf.Atan2(rot.y, rot.x);
            //x and y components for player movement
            float playerX = Mathf.Cos(playerAngle) * speed;
            float playerY = Mathf.Sin(playerAngle) * speed;
            //x and y components for bullet movement
            float bulletX = playerX;
            if (rot.x == 0)
            {
                bulletX = 0;
            }
            else if (playerMovement.rightBound - Mathf.Abs(playerPos.x) < 0.01)
            {
                bulletX = 0;
            }
            float bulletY = -1 * Mathf.Sqrt(Mathf.Pow(bullet.GetComponent<Projectile>().speed, 2) + Mathf.Pow(bulletX, 2));
            //firing angle determined
            tempAngle = Mathf.Atan2(bulletY, bulletX);
            //adjust for angle between enemy and player
            if ((angle * Mathf.Rad2Deg) < -90)
            {
                baseAngle = tempAngle * Mathf.Rad2Deg + ((angle * Mathf.Rad2Deg) % 90);
            }
            else
            {
                baseAngle = tempAngle * Mathf.Rad2Deg + ((angle * Mathf.Rad2Deg) + 90);
            }

            baseAngle -= 90;
        }
        else if (isAimedAtPlayerSimple)
        {
            // shoots at where player is currently
            Vector3 playerPos = playerMovement.transform.position;
            baseAngle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;
            baseAngle -= 90; // idk why but this fixes it
        }
        else
        {
            baseAngle = 180;
        }

        for (int i = 0; i < numBullets; i++)
        {
            float a = baseAngle - (spread / 2f) + (i * angleSlice);
            if (bulletManager != null)
            {
                GameObject b = bulletManager.CreateEnemyBullet(bullet).gameObject;
                b.transform.position = transform.position;
                b.transform.rotation = Quaternion.Euler(0, 0, a);
            }
            else
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, a, 0f));
            }
        }
    }
}
