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

    public Projectile CreateEnemyBullet(GameObject prefab)
    {
        Projectile bullet;
        // if already has bullet, remove from there
        if (!inactiveBullets.ContainsKey(prefab.name))
        {
            Debug.Log("adding new prefab.name " + prefab.name);
            inactiveBullets.Add(prefab.name, new Stack<Projectile>());
            activeBullets.Add(prefab.name, new List<Projectile>());
        }
        if (inactiveBullets[prefab.name].Count > 0)
        {
            Debug.Log("reusing existing");
            bullet = inactiveBullets[prefab.name].Pop();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("making new");
            GameObject bulletGameObj = Instantiate(prefab);
            bullet = bulletGameObj.GetComponent<Projectile>();
        }

        activeBullets[prefab.name].Add(bullet);

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

    public void RemoveEnemyBullet(Projectile bullet)
    {
        string name = bullet.gameObject.name;
        Debug.Log("verify this: " + name);
        int index = name.IndexOf("(Clone)");
        activeBullets[bullet.gameObject.name.Substring(0,index)].Remove(bullet);
        inactiveBullets[bullet.gameObject.name.Substring(0,index)].Push(bullet);
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

