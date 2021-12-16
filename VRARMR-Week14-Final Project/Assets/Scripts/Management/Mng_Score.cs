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

    //��ư
    public GameObject nextStage;
    public GameObject replay;

    //Ÿ�̸� text
    public Text timerText;
    public float time;
    private float countDown;

    //���� ȿ����
    public AudioClip getPresent; //���� ����� ��
    public AudioClip getWoodBox; //���� ���� ����� ��

    AudioSource ads;

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
    public void SetCountDown(int countDown)
    {
        this.countDown = countDown;
    }

    public void AddScore(int num)
    {
        ads.PlayOneShot(getPresent);

        score += num;
    }
    public void SubScore(int num)
    {
        ads.PlayOneShot(getWoodBox);

        score -= num;
    }

    private void Start()
    {
        //����� ������Ʈ ��������
        ads = GetComponent<AudioSource>();

        //Ÿ�̸� ����
        countDown = time;

        //goal �ؽ�Ʈ ����
        goalText.text = "Goal " + goal;

        isSuccess = false;
        isFail = false;
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
                //���� �������� ��ư�� Ȱ��ȭ �Ǿ� ���� �ʴٸ�
                if (nextStage.activeSelf == false)
                {
                    resultText.text = "Success!";
                    isSuccess = true;
                }
            }
            //����
            else if (score < goal)
            {
                //���÷��� ��ư�� Ȱ��ȭ �Ǿ� ���� �ʴٸ�
                if(replay.activeSelf == false)
                {
                    resultText.text = "Fail!";
                    isFail = true;
                }
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
                if (nextStage.activeSelf == false)
                {
                    resultText.text = "Success!";
                    isSuccess = true;
                }
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
