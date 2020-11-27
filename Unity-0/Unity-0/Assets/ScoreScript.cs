using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float currentScore = 0;
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void GetPoints(float scoreAdd)
    {
      currentScore += scoreAdd;
      scoreText.text = "Score: " + currentScore;
    }
}
