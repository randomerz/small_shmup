using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : MonoBehaviour
{
    public GameObject shieldPrefab;
    public float shieldVal;

    public EnemyWave myWave;
    public Dictionary<int, GameObject> shields = new Dictionary<int, GameObject>();

    private bool addedShields = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (!addedShields) // wait a frame for everything to spawn
        {
            if (myWave == null)
                Debug.LogWarning("Shielder is not a part of an EnemyWave");
            addedShields = true;
            foreach (Enemy e in myWave.enemies)
                AddShield(e, shieldVal);
        }
        foreach (Enemy e in myWave.enemies)
        {
            if (shields.ContainsKey(e.GetHashCode()))
            {
                if (e.tempHealth == 0)
                {
                    RemoveShield(e);
                }
            }
        }
    }

    private void AddShield(Enemy e, float s)
    {
        if (e.tempHealth == 0)
        {
            shields.Add(e.GetHashCode(), Instantiate(shieldPrefab, e.transform));
        }
        if (e.tempHealth < s)
        {
            e.tempHealth = s;
        }
    }

    private void RemoveShield(Enemy e)
    {
        e.tempHealth = 0;
        Destroy(shields[e.GetHashCode()]);
        shields.Remove(e.GetHashCode());
    }

    public void RemoveAllShields()
    {
        foreach (Enemy e in myWave.enemies)
            RemoveShield(e);
    }
}
