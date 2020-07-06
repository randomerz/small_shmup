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

    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private PlayerWeapon playerWeapon;

    public StageCompleteController stageCompleteController;

    public int currentStage;
    private float stageStartTime;
    private float stageFinishTime;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerWeapon = player.GetComponent<PlayerWeapon>();
    }
    
    void Update()
    {

    }

    // might not be needed if we just restart the scene each time
    public void StartGame()
    {
        playerMovement.canMove = true;
        playerWeapon.canShoot = true;
        playerHealth.currentHearts = player.GetComponent<PlayerHealth>().maxHearts;
        scoreManager.score = 0;
        stageStartTime = Time.time;
    }

    public void StageComplete()
    {
        stageFinishTime = Time.time;
        stageCompleteController.OpenStageComplete();
        playerWeapon.canShoot = false;
        StartCoroutine(StartDialogueDelay(2.25f)); // .75 + (1.5 - .75) + .75
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
        stageCompleteController.OpenStats(currentStage, 123456789, stageFinishTime - stageStartTime);
    }

    public void NextStage()
    {
        stageCompleteController.CloseStats();
        Debug.Log("open next scene after animation");
        StartCoroutine(StartNextStageDelay(1f)); // .75 + (1.5 - .75) + .75
    }

    public IEnumerator StartNextStageDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerMovement.canMove = false;
        player.GetComponent<Accelerated>().enabled = true;
        yield return new WaitForSeconds(delay);
        Debug.Log("Loading Scene " + (currentStage + 1));
        SceneManager.LoadScene("Stage" + (currentStage + 1));
        yield return null;
    }

    public void GameOver()
    {
        playerMovement.canMove = false;
        playerWeapon.canShoot = false;
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
