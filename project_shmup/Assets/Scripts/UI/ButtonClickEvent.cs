using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickEvent : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
