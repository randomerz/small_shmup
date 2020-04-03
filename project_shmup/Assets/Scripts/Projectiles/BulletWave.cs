using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWave : MonoBehaviour
{
    List<GameObject> bullets = new List<GameObject>();

    void Start()
    {
        foreach (Projectile b in GetComponentsInChildren<Projectile>())
            bullets.Add(b.gameObject);
    }

    public void DestroySelf()
    {
        foreach (GameObject b in bullets)
        {
            Destroy(b);
        }
        Destroy(gameObject);
    }
}
