using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingScreenController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectPanel;
    public GameObject optionsPanel;

    public bool isLevelSelectOpen = false;
    public bool isOptionsOpen = false;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isLevelSelectOpen)
                CloseLevelSelect();
            if (isOptionsOpen)
                CloseOptions();
        }
    }

    public void OpenLevelSelect()
    {
        isLevelSelectOpen = true;
        mainMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void CloseLevelSelect()
    {
        isLevelSelectOpen = false;
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    public void OpenOptions()
    {
        isOptionsOpen = true;
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        isOptionsOpen = false;
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void LoadStage(int i)
    {
        print("loading stage " + i);
        SceneManager.LoadScene("Stage" + i);
    }


    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit(0);
    }

    //public void OpenGame()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}
}
