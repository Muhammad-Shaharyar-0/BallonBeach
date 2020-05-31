using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int HighScore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI HighScoreUI;
    public TextMeshProUGUI YourScoreUI;
    private void Start()
    {
      
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString();
        HighScoreUI.text = "High Score  " + HighScore.ToString();
        YourScoreUI.text= "Your Score " + score.ToString();
        if (HighScore < score)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("gap"))
        {
            score++;
           
        }
         
    }
}

