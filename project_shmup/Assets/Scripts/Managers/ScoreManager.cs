using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    public float extraLifeBonus = 50000;

    public Text scoreText;  // update this to tmpro

    private void Start()
    {
        score = 0;
    }
   
    void Update()
    {
        scoreText.text = score.ToString();
    }


    public void AddScore(float s)
    {
        score += s;
    }
}
