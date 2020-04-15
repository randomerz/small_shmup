
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreManager scoreM;
    public Text score;

    // Update is called once per frame
    void Update()
    {
        score.text = scoreM.GetScore().ToString();
    }
}
