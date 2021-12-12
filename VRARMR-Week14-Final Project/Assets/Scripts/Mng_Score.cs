using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mng_Score : MonoBehaviour
{
    public static Mng_Score instance;
    
    public Text scoreText;
    public Text goalText;
    public Text resultText;

    private int score;
    private int goal;

    private bool isSuccess;
    private bool isFail;

    private bool isStartbtnClicked;

    //getter & setter
    public int GetScore()
    {
        return score;
    }
    public int GetGoal()
    {
        return goal;
    }
    public bool GetIsSuccess()
    {
        return isSuccess;
    }
    public bool GetIsFail()
    {
        return isFail;
    }    
    public void SetScore(int score)
    {
        this.score = score;
    }
    public void SetGoal(int goal)
    {
        this.goal = goal;
    }
    public void SetIsSuccess(bool isSuccess)
    {
        this.isSuccess = isSuccess;
    }
    public void SetIsFail(bool isFail)
    {
        this.isFail = isFail;
    }
    public void SetIsStartbtnClicked(bool isStartbtnClicked)
    {
        this.isStartbtnClicked = isStartbtnClicked;
    }

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void AddScore(int num)
    {
        score += num;
    }
    public void SubScore(int num)
    {
        score -= num;
    }

    private void Start()
    {
        score = 5;
        goal = 15;

        isSuccess = false;
        isFail = false;
        isStartbtnClicked = false;
    }

    private void Update()
    {
        if (isStartbtnClicked)
        {
            scoreText.text = "Present " + score;
            goalText.text = "Goal " + goal;

            //게임 종료
            //성공
            if (score >= goal)
            {
                resultText.text = "Success!";
                isSuccess = true;
            }
            else if (score < 0)
            {
                resultText.text = "Fail!";
                isFail = true;
            }
        }
    }

}
