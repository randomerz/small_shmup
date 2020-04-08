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
            Vector3 playerPos = playerMovement.transform.position;
            float speed = playerMovement.speed;
            Vector3 rot = playerMovement.move;
            //find angle between enemy and player
            Vector3 diff = playerPos - transform.position;
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            float tempAngle = 0;
            float playerSlope = 0;
            float x;
            float y;
            
            playerSlope = rot.y / rot.x * speed;
            
            //minimum difference in t1 and t2, will make sense after reading all the code
            float tempDiff = 100;
            if (rot.x > 0)
            {
                for (int a = (int)angle + 1; a < 361; a++)
                {
                    float bulletSlope = Mathf.Tan(a) * bullet.GetComponent<Projectile>().speed;
                    x = (bulletSlope * transform.position.x - transform.position.y - playerSlope * playerPos.x + playerPos.y) / (bulletSlope - playerSlope);
                    y = bulletSlope * (x - transform.position.x) + transform.position.y;
                    float distanceEnemy = Mathf.Sqrt(Mathf.Pow(y - transform.position.y, 2) + Mathf.Pow(x - transform.position.x, 2));
                    float distancePlayer = Mathf.Sqrt(Mathf.Pow(y - playerPos.y, 2) + Mathf.Pow(x - playerPos.x, 2));
                    float timeEnemy = distanceEnemy / bullet.GetComponent<Projectile>().speed;
                    float timePlayer = distancePlayer / bullet.GetComponent<Projectile>().speed;
                    if (Mathf.Abs(timeEnemy - timePlayer) < tempDiff)
                    {
                        tempDiff = Mathf.Abs(timeEnemy - timePlayer);
                        tempAngle = a;
                    }
                }
                baseAngle = tempAngle;
            }
            else
            {
                for (int a = 180; a < (int)angle; a++)
                {
                    float bulletSlope = Mathf.Tan(a) * bullet.GetComponent<Projectile>().speed;
                    x = (bulletSlope * transform.position.x - transform.position.y - playerSlope * playerPos.x + playerPos.y) / (bulletSlope - playerSlope);
                    y = bulletSlope * (x - transform.position.x) + transform.position.y;
                    float distanceEnemy = Mathf.Sqrt(Mathf.Pow(y - transform.position.y, 2) + Mathf.Pow(x - transform.position.x, 2));
                    float distancePlayer = Mathf.Sqrt(Mathf.Pow(y - playerPos.y, 2) + Mathf.Pow(x - playerPos.x, 2));
                    float timeEnemy = distanceEnemy / bullet.GetComponent<Projectile>().speed;
                    float timePlayer = distancePlayer / bullet.GetComponent<Projectile>().speed;
                    if (Mathf.Abs(timeEnemy - timePlayer) < tempDiff)
                    {
                        tempDiff = Mathf.Abs(timeEnemy - timePlayer);
                        tempAngle = a;
                    }
                }
                baseAngle = tempAngle;
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
