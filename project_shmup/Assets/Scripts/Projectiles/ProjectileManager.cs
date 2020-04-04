using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileManager : MonoBehaviour
{
    // ArrayList myList = new ArrayList();
    ArrayList enemyActiveBullets;
    ArrayList enemyInactiveBullets;
    ArrayList playerActiveBullets;
    ArrayList playerInactiveBullets;
    // Start is called before the first frame update
    void Start()
    {
        activeBullets = new ArrayList();
        inactiveBullets = new ArrayList();
    }

    Projectile makeEnemyBullet()
    {
        Projectile bullet;
        // Take a bullet out of the inactive pool
        if (enemyInactiveBullets.Count > 0)
        {
            bullet = enemyInactiveBullets.Remove();
        }

        Instantiate(bullet);
        enemyActiveBullets.Add(bullet);
        return bullet;
    }
    playerBullet makeBullet()
    {
        playerBullet bullet;
        // Take a bullet out of the inactive pool
        if (playerInactiveBullets.Count > 0)
        {
            return playerInactiveBullets.Remove();

        }
        Instantiate(bullet);
        playerActiveBullets.Add(bullet);
        return bullet;
    }
    void enemySetInactive(Projectile bullet)
    {
        enemyActiveBullets.RemoveAt(enemyActiveBullets.IndexOf(bullet));
        enemyInactiveBullets.Add(bullet);
    }
    void playerSetInactive(playerBullet bullet)
    {
        playerActiveBullets.RemoveAt(playerActiveBullets.IndexOf(bullet));
        playerInactiveBullets.Add(bullet);
    }

    void FixedUpdate()
    {
        // update active/ inactive bullets 
    }
}

