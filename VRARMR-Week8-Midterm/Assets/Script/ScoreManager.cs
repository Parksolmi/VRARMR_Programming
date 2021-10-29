using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 
    public Text scoreText;
    public Text gameResult;

    private int score = 0;
    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (score >= 10)
        {
            gameResult.text = "Game Clear";
        }
    }

}

