using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageCompleteController : MonoBehaviour
{
    public LT_Slide stageCompleteSlider;
    public LT_Slide statsSlider;
    public LT_Slide restartSlider;

    public Vector3 stageCompleteVector = new Vector3(2220, 0);
    public Vector3 statsVector = new Vector3(2520, 0);
    public Vector3 restartVector = new Vector3(2520, 0);

    public TextMeshProUGUI statsTitle;
    public TextMeshProUGUI statsScore;
    public TextMeshProUGUI statsTime;

    public 

    void Start()
    {
        
    }
    
    void Update()
    {

    }

    public void OpenStageComplete()
    {
        stageCompleteSlider.gameObject.SetActive(true);
        stageCompleteSlider.gameObject.GetComponent<RectTransform>().anchoredPosition = -stageCompleteVector;
        stageCompleteSlider.SlideTo(Vector3.zero);
        stageCompleteSlider.SlideToDelayDisable(stageCompleteVector, 1.5f);
    }

    public void OpenStats(int currentStage, float score, float time)
    {
        statsTitle.text = "Stage " + currentStage;
        statsScore.text = score.ToString();
        float minutes = time / 60;
        float seconds = time % 60;
        statsTime.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        statsSlider.gameObject.SetActive(true);
        statsSlider.gameObject.GetComponent<RectTransform>().anchoredPosition = -statsVector;
        statsSlider.SlideTo(Vector3.zero);
    }

    public void OpenRestart()
    {
        restartSlider.gameObject.SetActive(true);
        restartSlider.gameObject.GetComponent<RectTransform>().anchoredPosition = -restartVector;
        restartSlider.SlideTo(Vector3.zero);
    }

    public void CloseStageComplete()
    {
        stageCompleteSlider.gameObject.SetActive(false);
        stageCompleteSlider.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    public void CloseStats()
    {
        statsSlider.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        statsSlider.SlideToDelayDisable(statsVector);
    }

    public void CloseRestart()
    {
        restartSlider.gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        restartSlider.SlideToDelayDisable(restartVector);
    }

}
