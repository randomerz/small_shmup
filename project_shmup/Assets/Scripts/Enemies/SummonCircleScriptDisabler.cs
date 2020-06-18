using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCircleScriptDisabler : MonoBehaviour
{
    public GameObject summon;
    public float tpDelayTime = 0f;
    public float delayTime = 2f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private SpriteRenderer summonSpriteRenderer;
    private Animator summonAnimator;
    private List<MonoBehaviour> scripts = new List<MonoBehaviour>();
    private List<Collider2D> colliders = new List<Collider2D>();

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        summonSpriteRenderer = summon.GetComponent<SpriteRenderer>();
        summonAnimator = summon.GetComponent<Animator>();
        foreach (MonoBehaviour s in summon.GetComponents<MonoBehaviour>())
        {
            if (s.enabled)
            {
                s.enabled = false;
                scripts.Add(s);
            }
        }
        foreach (Collider2D c in summon.GetComponents<Collider2D>())
        {
            if (c.enabled)
            {
                c.enabled = false;
                colliders.Add(c);
            }
        }
        if (tpDelayTime > 0)
        {
            spriteRenderer.enabled = false;
            animator.enabled = false;
            summonSpriteRenderer.enabled = false;
            summonAnimator.enabled = false;
            delayTime += tpDelayTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tpDelayTime <= 0)
        {
            spriteRenderer.enabled = true;
            animator.enabled = true;
            summonSpriteRenderer.enabled = true;
            summonAnimator.enabled = true;
        }
        if (delayTime <= 0)
        {
            foreach (MonoBehaviour s in scripts)
                s.enabled = true;
            foreach (Collider2D c in colliders)
                c.enabled = true;
            Destroy(gameObject);
        }
        tpDelayTime -= Time.deltaTime;
        delayTime -= Time.deltaTime;
    }
}
