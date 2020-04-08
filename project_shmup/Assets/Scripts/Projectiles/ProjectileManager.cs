using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileManager : MonoBehaviour
{
    // ArrayStack myStack = new ArrayStack();
    List<Projectile> enemyActiveBullets = new List<Projectile>();
    List<PlayerBullet> playerActiveBullets = new List<PlayerBullet>();

    Stack<Projectile> enemyInactiveBullets = new Stack<Projectile>();
    public Stack<PlayerBullet> playerInactiveBullets = new Stack<PlayerBullet>();

    void Start()
    {

    }

    public Projectile CreateEnemyBullet(GameObject prefab)
    {
        Projectile bullet;
        // if already has bullet, remove from there
        if (enemyInactiveBullets.Count > 0)
        {
            bullet = enemyInactiveBullets.Pop();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            GameObject bulletGameObj = Instantiate(prefab);
            bullet = bulletGameObj.GetComponent<Projectile>();
        }

        enemyActiveBullets.Add(bullet);

        Projectile prefabBullet = prefab.GetComponent<Projectile>();
        bullet.speed = prefabBullet.speed;
        return bullet;
    }

    public PlayerBullet CreatePlayerBullet(GameObject prefab)
    {
        PlayerBullet bullet;

        if (playerInactiveBullets.Count > 0)
        {
            bullet = playerInactiveBullets.Pop();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            GameObject bulletGameObj = Instantiate(prefab);
            bullet = bulletGameObj.GetComponent<PlayerBullet>();
        }

        playerActiveBullets.Add(bullet);
        return bullet;
    }

    public void RemoveEnemyBullet(Projectile bullet)
    {
        enemyActiveBullets.Remove(bullet);
        enemyInactiveBullets.Push(bullet);
        bullet.gameObject.SetActive(false);
    }

    public void RemovePlayerBullet(PlayerBullet bullet)
    {
        playerActiveBullets.Remove(bullet);
        playerInactiveBullets.Push(bullet);
        bullet.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // update active/ inactive bullets 
    }
}

