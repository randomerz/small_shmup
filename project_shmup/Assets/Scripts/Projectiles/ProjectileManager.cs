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

    public GameObject playerBullet;
    public GameObject genericBullet;

    void Start()
    {

    }

    public Projectile MakeEnemyBullet()
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
            GameObject bulletGameObj = Instantiate(genericBullet);
            bullet = bulletGameObj.GetComponent<Projectile>();
        }

        enemyActiveBullets.Add(bullet);
        return bullet;
    }

    public PlayerBullet MakePlayerBullet()
    {
        PlayerBullet bullet;

        if (playerInactiveBullets.Count > 0)
        {
            bullet = playerInactiveBullets.Pop();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            GameObject bulletGameObj = Instantiate(playerBullet);
            bullet = bulletGameObj.GetComponent<PlayerBullet>();
        }

        playerActiveBullets.Add(bullet);
        return bullet;
    }

    public void SetInactiveEnemy(Projectile bullet)
    {
        enemyActiveBullets.Remove(bullet);
        enemyInactiveBullets.Push(bullet);
        bullet.gameObject.SetActive(false);
    }

    public void SetInactivePlayer(PlayerBullet bullet)
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

