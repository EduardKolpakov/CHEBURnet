using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static Text scoreText;
    private static int score = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    // Метод для добавления очков
    public static void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Метод для обновления текста
    static void UpdateScoreText()
    {
        scoreText.text = "SCORE: \n" + score.ToString();
    }

    public static int GetScore() { return score; }

    public static void RemoveScore()
    {
        score = 0;
        UpdateScoreText();
    }
}