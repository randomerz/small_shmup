using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCircleScriptDisabler : MonoBehaviour
{
    public GameObject summon;
    public float delayTime = 2f;
    private List<MonoBehaviour> scripts = new List<MonoBehaviour>();
    private List<Collider2D> colliders = new List<Collider2D>();

    void Start()
    {
        foreach (MonoBehaviour s in summon.GetComponents<MonoBehaviour>())
        {
            s.enabled = false;
            scripts.Add(s);
        }
        foreach (Collider2D c in summon.GetComponents<Collider2D>())
        {
            c.enabled = false;
            colliders.Add(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTime <= 0)
        {
            foreach (MonoBehaviour s in scripts)
                s.enabled = true;
            foreach (Collider2D c in colliders)
                c.enabled = true;
            Destroy(gameObject);
        }
        delayTime -= Time.deltaTime;
    }
}
