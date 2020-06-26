using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public ScoreManager scoreManager;
    public WaveManager waveManager;
    public ProjectileManager projManager;
    public SoundManager soundManager;
    // public DialogueManager dialogueManager;

    public StageCompleteController stageCompleteController;

    public int currentStage;

    void Start()
    {
        
    }
    
    void Update()
    {

    }

    // might not be needed if we just restart the scene each time
    public void StartGame()
    {
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<PlayerWeapon>().canShoot = true;
        player.GetComponent<PlayerHealth>().currentHearts = player.GetComponent<PlayerHealth>().maxHearts;
        scoreManager.score = 0;
    }

    public void StageComplete()
    {
        stageCompleteController.OpenStageComplete();
        player.GetComponent<PlayerWeapon>().canShoot = false;
        StartCoroutine("StartDialogueDelay", 2.25f); // .75 + (1.5 - .75) + .75
    }

    public IEnumerator StartDialogueDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StageCompleteDialogue();
        yield return null;
    }

    public void StageCompleteDialogue()
    {
        Debug.Log("stage complete dialogue");
        StageCompleteStats(); // temporary just call the next function
    }

    public void StageCompleteStats()
    {
        stageCompleteController.OpenStats();
    }

    public void NextStage()
    {
        stageCompleteController.CloseStats();
        Debug.Log("open next scene after animation");
    }

    public void GameOver()
    {
        player.GetComponent<PlayerMovement>().canMove = false;
        player.GetComponent<PlayerWeapon>().canShoot = false;
        stageCompleteController.OpenRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // need to fix this so its better
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("LandingScene");
    }
}
