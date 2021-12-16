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

    //버튼
    public GameObject nextStage;
    public GameObject replay;

    //타이머 text
    public Text timerText;
    public float time;
    private float countDown;

    //점수 효과음
    public AudioClip getPresent; //선물 얻었을 때
    public AudioClip getWoodBox; //나무 상자 얻었을 때

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
        //오디오 컴포넌트 가져오기
        ads = GetComponent<AudioSource>();

        //타이머 설정
        countDown = time;

        //goal 텍스트 설정
        goalText.text = "Goal " + goal;

        isSuccess = false;
        isFail = false;
    }

    private void Update()
    {
        //score text 업데이트
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Present " + score;

        //시간초과
        if (Mathf.Floor(countDown)<=0)
        {
            //게임 종료
            //성공
            if (score >= goal)
            {
                //다음 스테이지 버튼이 활성화 되어 있지 않다면
                if (nextStage.activeSelf == false)
                {
                    resultText.text = "Success!";
                    isSuccess = true;
                }
            }
            //실패
            else if (score < goal)
            {
                //리플레이 버튼이 활성화 되어 있지 않다면
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

            //게임 종료
            //성공
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
