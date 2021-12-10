using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//게임 상태(각 스테이지)를 알려주는 변수
public enum GameState
{
    Ready, //준비 : 게임 시작 전
    Stage1, //스테이지 1
    Stage2, //스테이지 2
    Stage3 //스테이지 3
}

//게임 진행을 위한 Management클래스
public class GameMng : MonoBehaviour
{
    //시작 전 : 게임 스테이지 Ready로 설정
    public GameState gameState = GameState.Ready;

    public Text startMsg; //시작 메세지를 저장할 변수

    public SantaIdle playerIdle; //플레이어 객체 : 처음 시작 할 때 플레이어
    public Santa1Ctrl stage1Player; //플레이어 객체 : 스테이지 1 플레이어


    public GameObject backGround; //배경 오브젝트를 저장할 변수

    public GameObject startBtn; //시작 버튼을 저장할 변수

    //박스 오브젝트와의 충돌 여부를 저장하는 변수
    private bool isCollisionP; //선물 상자와의 충돌 여부
    private bool isCollisionB; //나무 상자와의 충돌 여부

    //게임이 시작했는지 여부를 저장하는 변수
    private bool isStart = false;

    //게임 종료 조건 변수
    private int score; //점수
    private int goal; //목표 숫자 : 선물을 획득해야 하는 숫자

    //게임 진행 메세지
    public Text scoreMsg; //점수 보여주는 메세지
    public Text goalMsg; //생명 보여주는 메세지
    public Text resultMsg; //결과 보여주는 메세지

    //스테이지2로 넘어가는 버튼
    public GameObject stage2Btn;


    private void Start()
    {
        
    }


    private void Update()
    {
        //Ready상태일 때 실행
        if (gameState == GameState.Ready)
        {
            if (playerIdle.isDetected) //플레이어 객체가 감지되었을 때
            {
                //스타트 버튼이 활성화되어있지 않다면
                if (startBtn.activeSelf == false)
                {
                    //스타트 버튼 활성화 시키기
                    startBtn.SetActive(true);
                    //확인 되었음을 알리는 메세지 출력하기
                    startMsg.text = "확인되셨습니다";
                }
            }
            else //플레이어 객체가 감지되지 않았을 때
            {
                //스타트 버튼이 활성화 되어 있다면
                if (startBtn.activeSelf)
                {
                    //스타트 버튼이 보이지 않도록 비활성화 시키기
                    startBtn.SetActive(false);
                    //카드 인식을 위한 메세지 출력하기
                    startMsg.text = "산타협회 회원증을 제시해주세요";
                }
            }
        }

        //Stage1에서 게임 종료 조건
        if (gameState == GameState.Stage1)
        {
            if(!isStart)
            {
                //게임 시작 전 score, goal변수 설정
                score = 0;
                goal = 15;

                scoreMsg.text = "Present " + score;
                goalMsg.text = "Goal " + goal;

                isStart = true;
            }
            else
            {
                //박스와 충돌 시 Score 점수 수정
                if (isCollisionP) //선물 상자와 충돌한 경우
                {
                    PlusScore();
                    isCollisionP = false;
                }
                if (isCollisionB) //나무 상자와 충돌한 경우
                {
                    MinusScore();
                    isCollisionB = false;
                }

                //게임 종료 조건
                //성공
                if (score >= goal)
                {
                    resultMsg.text = "Success";
                    stage1Player.GetComponent<GnrtBox>().enabled = false;
                    //스테이지2로 넘어가는 버튼

                }
                //실패
                if (score < 0)
                {
                    resultMsg.text = "Fail";
                    stage1Player.GetComponent<GnrtBox>().enabled = false;
                    //다시하기 버튼

                }
            }
        }
    }

    //버튼 이벤트
    //시작 버튼 눌렀을 때 이벤트
    public void OnClickStartBtn()
    {
        //게임 스테이지 넘기기
        gameState = GameState.Stage1;
        //플레이어 교체
        playerIdle.setActiveFalse();
        stage1Player.setActiveTrue();
        //배경활성화
        backGround.SetActive(true);
        //메세지 지우기
        startMsg.text = null;
        //버튼 지우기
        startBtn.SetActive(false);
    }

    //Stage2로 넘어가는 버튼 이벤트
    public void OnClickStage2Btn()
    {
        //게임 스테이지 넘기기
        gameState = GameState.Stage2;
        //플레이어 교체
        stage1Player.setActiveFalse();

    }

    //충돌 변수 설정
    public void SetIsCollisionP(bool collision)
    {
        isCollisionP = collision; 
    }
    public void SetIsCollisionB(bool collision)
    {
        isCollisionB = collision;
    }

    //스테이지1 score 증감 함수
    public void PlusScore()
    {
        score++;
        scoreMsg.text = "Score " + score;
    }
    public void MinusScore()
    {
        score -= 3;
        scoreMsg.text = "Score " + score;
    }

}
