using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Animator animator;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float baseAngle;
        Vector3 playerPos = playerMovement.transform.position;
        baseAngle = Mathf.Atan2(playerPos.y - transform.position.y, playerPos.x - transform.position.x) * Mathf.Rad2Deg;
        baseAngle -= 90; // idk why but this fixes it
        animator.SetFloat("Angle", baseAngle);
    }
}
