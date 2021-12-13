using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mng_Score : MonoBehaviour
{
    public Text scoreText;
    public Text goalText;
    public Text resultText;

    public int score;
    public int goal;

    private bool isSuccess;
    private bool isFail;

    private bool isStartbtnClicked;

    //Ÿ�̸� text
    public Text timerText;
    public float time;
    private float countDown;

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
        //Ÿ�̸� ����
        countDown = time;

        //goal �ؽ�Ʈ ����
        goalText.text = "Goal " + goal;

        isSuccess = false;
        isFail = false;
        isStartbtnClicked = false;
    }

    private void Update()
    {
        //score text ������Ʈ
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Present " + score;

        //�ð��ʰ�
        if (Mathf.Floor(countDown)<=0)
        {
            //���� ����
            //����
            if (score >= goal)
            {
                resultText.text = "Success!";
                isSuccess = true;
            }
            else if (score < goal)
            {
                resultText.text = "Fail!";
                isFail = true;
            }
        }
        else
        {
            countDown -= Time.deltaTime;
            timerText.text = Mathf.Floor(countDown).ToString();

            //���� ����
            //����
            if (score >= goal)
            {
                resultText.text = "Success!";
                isSuccess = true;
            }
        }
        
    }

    public void SetTimer()
    {
        countDown = time;
    }

    public void PlusCountDown(int num)
    {
        countDown += num;
    }

    public void MinusCountDown(int num)
    {
        countDown -= num;
    }
}
