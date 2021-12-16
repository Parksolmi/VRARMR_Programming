using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//점수 관리 클래스
public class Mng_Score : MonoBehaviour
{
    public Text scoreText; //점수 text
    public Text goalText; //목표치 text
    public Text resultText; //결과 text

    public int score; //점수 정수 변수
    public int goal; //목표치 정수 변수

    private bool isSuccess; //성공여부 저장 할 변수
    private bool isFail; //실패 여부 저장 할 변수

    //버튼
    public GameObject nextStage; //다음 스테이지 버튼을 저장 할 변수
    public GameObject replay; //다시하기 버튼을 저장 할 변수

    //타이머 text
    public Text timerText; //타이머 text
    public float time; //초기 시간 float변수
    private float countDown; //카운트 다운 되고 있는 수를 저장 할 float변수

    //점수 효과음 - 오디오클립
    public AudioClip getPresent; //선물 얻었을 때
    public AudioClip getWoodBox; //나무 상자 얻었을 때

    AudioSource ads; //오디오 컴포넌트를 저장 할 변수

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

    //점수 획득하는 함수
    public void AddScore(int num)
    {
        ads.PlayOneShot(getPresent);

        score += num;
    }
    //점수 감소시키는 함수
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

        //성공/실패 여부 변수 false로 설정
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
            //성공한 경우
            if (score >= goal)
            {
                //다음 스테이지 버튼이 활성화 되어 있지 않다면
                if (nextStage.activeSelf == false)
                {
                    //결과 메세지 띄우기
                    resultText.text = "Success!";
                    //성공 여부 true로 설정
                    isSuccess = true;
                }
            }
            //실패한 경우
            else if (score < goal)
            {
                //리플레이 버튼이 활성화 되어 있지 않다면
                if(replay.activeSelf == false)
                {
                    //결과 메세지 띄우기
                    resultText.text = "Fail!";
                    //실패 여부 true 설정
                    isFail = true;
                }
            }
        }
        else //게임 진행 중
        {
            //카운트다운하기
            countDown -= Time.deltaTime;
            timerText.text = Mathf.Floor(countDown).ToString(); //남은 시간 text로 보여주기

            //게임 종료
            //시간이 남았지만 목표치를 도달하여 성공한 경우
            if (score >= goal)
            {
                //다음 스테이지 버튼이 비활성화 되어 있다면
                if (nextStage.activeSelf == false)
                {
                    //결과 메세지 띄우기
                    resultText.text = "Success!";
                    //성공 여부 변수 true로 설정
                    isSuccess = true;
                }
            }
        }
        
    }

    //타이머 set하는 함수
    public void SetTimer()
    {
        countDown = time;
    }
    //카운트 다운 plus하는 함수
    public void PlusCountDown(int num)
    {
        countDown += num;
    }
    //카운트 다운 minus하는 함수
    public void MinusCountDown(int num)
    {
        countDown -= num;
    }
}
