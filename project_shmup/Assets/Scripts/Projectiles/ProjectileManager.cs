using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileManager : MonoBehaviour
{
    // ArrayStack myStack = new ArrayStack();

    Dictionary<string, Stack<Projectile>> inactiveBullets = new Dictionary<string, Stack<Projectile>>();
    Dictionary<string, List<Projectile>> activeBullets = new Dictionary<string, List<Projectile>>();

    List<PlayerBullet> playerActiveBullets = new List<PlayerBullet>();
    Stack<PlayerBullet> playerInactiveBullets = new Stack<PlayerBullet>();

    void Start()
    {

    }

    public Projectile CreateEnemyBullet(GameObject prefab, string type)
    {
        Projectile bullet;
        // if already has bullet, remove from there
        if (!inactiveBullets.ContainsKey(type))
        {
            Debug.Log("adding new type " + type);
            inactiveBullets.Add(type, new Stack<Projectile>());
            activeBullets.Add(type, new List<Projectile>());
        }
        if (inactiveBullets[type].Count > 0)
        {
            Debug.Log("reusing bullet of type " + type);
            bullet = inactiveBullets[type].Pop();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("making new");
            GameObject bulletGameObj = Instantiate(prefab);
            bullet = bulletGameObj.GetComponent<Projectile>();
        }

        activeBullets[type].Add(bullet);

        Projectile prefabBullet = prefab.GetComponent<Projectile>();
        bullet.speed = prefabBullet.speed;
        return bullet;
    }

    public PlayerBullet CreatePlayerBullet(GameObject prefab, Transform firePoint)
    {
        PlayerBullet bullet;

        if (playerInactiveBullets.Count > 0)
        {
            bullet = playerInactiveBullets.Pop();
            bullet.gameObject.SetActive(true);
            Debug.Log("Re-used player bullet");
        }
        else
        {
            GameObject bulletGameObj = Instantiate(prefab);
            bullet = bulletGameObj.GetComponent<PlayerBullet>();
            Debug.Log("Made player bullet");
        }

        playerActiveBullets.Add(bullet);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        return bullet;
    }

    public void RemoveEnemyBullet(Projectile bullet, string type)
    {
        activeBullets[type].Remove(bullet);
        inactiveBullets[type].Push(bullet);
        bullet.gameObject.SetActive(false);
    }

    public void RemovePlayerBullet(PlayerBullet bullet)
    {
        playerActiveBullets.Remove(bullet);
        playerInactiveBullets.Push(bullet);
        bullet.gameObject.SetActive(false);
        Debug.Log("bullet deactivated");
    }

    void FixedUpdate()
    {
        // update active/ inactive bullets 
    }
}

