using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float totalScore;
    private float bonus;

    private void Start()
    {
        totalScore = 0;
    }

    public void AddScore(float addition)
    {
        totalScore += addition;
    }

    // Update is called once per frame
    public float GetScore()
    {
        return totalScore;
    }
    
    public void AddBonus()
    {
        totalScore += bonus;
    }

    void Update()
    {
        
    }
}
