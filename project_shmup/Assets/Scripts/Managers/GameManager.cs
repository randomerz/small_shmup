using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public ScoreManager scoreManager;
    public WaveManager waveManager;
    public ProjectileManager projManager;
    public SoundManager soundManager;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void GameOver()
    {
        player.GetComponent<PlayerMovement>().canMove = false;
        player.GetComponent<PlayerWeapon>().canShoot = false;
    }

        // might not be needed if we just restart the scene each time
    public void StartGame()
    {
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<PlayerWeapon>().canShoot = true;
        player.GetComponent<PlayerHealth>().currentHearts = player.GetComponent<PlayerHealth>().maxHearts;
        scoreManager.score = 0;
    }
}
