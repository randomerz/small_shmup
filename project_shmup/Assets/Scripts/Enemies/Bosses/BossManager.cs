using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int health = 100;
    private int maxHP;
    public float shift = 2f;
    public GameObject player;
    public BossBehavior behavior;
    public BossWeapon shooter;

    private bool phase1 = true;
    private bool phase2 = false;
    private bool phase3 = false;
    private float cycle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHP * .4 < health)
        {
            cycle += Time.deltaTime;
            if (cycle >= shift)
            {
                behavior.Teleport();
                cycle = 0f;
                if(maxHP *.75 > health)
                {
                    shift *= .5f;
                }
            }
        }
        else
        {
            Debug.Log(maxHP);
        }
    }
    public void TakeDamage()
    {
        health -= 1;
        if (health<= 0)
        {
            Destroy(gameObject);
        }
    }
}
