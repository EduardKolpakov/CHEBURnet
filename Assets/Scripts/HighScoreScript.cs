using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    private static Text highscoreText;
    private static int highscore = 0;
    void Start()
    {
        highscoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    static void UpdateScoreText()
    {
        highscoreText.text = "HIGHSCORE: \n" + highscore.ToString();
    }

    public static void setHighScore(int sc)
    {
        highscore = sc;
        UpdateScoreText();
    }
    public static int GetHighScore()
    { return highscore; }
}
