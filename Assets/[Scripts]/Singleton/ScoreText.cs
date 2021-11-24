using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Score Attributes
    private float score;
    private Text scoreText;

    // Singleton
    public static ScoreText Instance { get; private set; }

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        Instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}