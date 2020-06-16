using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayScripts : MonoBehaviour
{
    public float delayTime = 1f;
    private List<MonoBehaviour> scripts = new List<MonoBehaviour>();

    void Start()
    {
        foreach (MonoBehaviour s in GetComponents<MonoBehaviour>())
            if (s.enabled && s.GetType() != typeof(DelayScripts))
            {
                s.enabled = false;
                scripts.Add(s);
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTime <= 0)
        {
            foreach (MonoBehaviour s in scripts)
                s.enabled = true;
            GetComponent<DelayScripts>().enabled = false;
        }
        delayTime -= Time.deltaTime;
    }
}
