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
    public Santa2Ctrl stage2Player; //플레이어 객체 : 스테이지 2 플레이어

    public GameObject gun; //총 오브젝트 저장하는 변수

    public GameObject backGround; //배경 오브젝트를 저장할 변수

    public GameObject startBtn; //시작 버튼을 저장할 변수

    //박스 오브젝트와의 충돌 여부를 저장하는 변수
    private bool isCollisionP; //선물 상자와의 충돌 여부
    private bool isCollisionB; //나무 상자와의 충돌 여부

    //게임이 시작했는지 여부를 저장하는 변수
    private bool isStart = false;

    //스테이지2로 넘어가는 버튼
    public GameObject stage2Btn;
    //다시 시작하기 버튼
    public GameObject replayBtn;

    //게임 종료 조건 변수
    bool isSuccess;
    bool isFail;

    private void Update()
    {
        //Ready상태일 때 실행
        if (gameState == GameState.Ready)
        {
            //필요 없는 버튼 비활성화
            stage2Btn.SetActive(false);
            replayBtn.SetActive(false);

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

        //게임 종료 조건
        isSuccess = ScoreMng.instance.GetIsSuccess();
        isFail = ScoreMng.instance.GetIsFail();

        //Stage1
        if (gameState == GameState.Stage1)
        {
            if(!isStart)
            {
                //게임 시작 전 score, goal변수 설정
                ScoreMng.instance.SetScore(5);
                ScoreMng.instance.SetGoal(15);
                
                isStart = true;
            }
            else
            {                
                //성공
                if (isSuccess)
                {
                    //박스 생성 멈춤
                    stage1Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //스테이지2로 넘어가는 버튼
                    stage2Btn.SetActive(true);

                    ScoreMng.instance.SetIsSuccess(false);
                }
                //실패
                else if (isFail)
                {
                    //박스 생성 멈춤
                    stage1Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //다시하기 버튼
                    replayBtn.SetActive(true);

                    ScoreMng.instance.SetIsFail(false);
                }
            }
        }

        
        //Stage2
        if (gameState == GameState.Stage2)
        {
            if (!isStart)
            {
                //게임 시작 전 score, goal변수 설정
                ScoreMng.instance.SetScore(10);
                ScoreMng.instance.SetGoal(30);

                isStart = true;

            }
            else
            {
                //게임 종료 조건
                //성공
                if (isSuccess)
                {
                    //박스 생성 멈춤
                    stage2Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //스테이지2로 넘어가는 버튼
                    //stage2Btn.SetActive(true);
                }
                //실패
                else if (isFail)
                {
                    //박스 생성 멈춤
                    stage2Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //다시하기 버튼
                    //replayBtn.SetActive(true);
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
        //score text 띄우기
        ScoreMng.instance.SetIsStartbtnClicked(true);
    }

    //Stage2로 넘어가는 버튼 이벤트
    public void OnClickStage2Btn()
    {
        //게임 스테이지 넘기기
        gameState = GameState.Stage2;
        //플레이어 교체
        stage1Player.setActiveFalse();
        stage2Player.setActiveTrue();
        //총 오브젝트 활성화
        gun.SetActive(true);
        //결과 메세지 지우기
        ScoreMng.instance.resultText.text = null;
        //버튼 지우기
        stage2Btn.SetActive(false);
        //isStart 변수 설정
        isStart = false;

        //박스 생성 다시 시작
        stage2Player.GetComponent<GnrtBox>().InvokeGnrt();

    }

    //Replay버튼 이벤트
    public void OnClickReplayBtn()
    {
        //게임 시작 전 score, goal변수 설정
        ScoreMng.instance.SetScore(5);
        ScoreMng.instance.SetGoal(15);

        //결과 메세지 지우기
        ScoreMng.instance.resultText.text = null;

        //버튼 지우기
        replayBtn.SetActive(false);
        
        //박스 생성 다시 시작
        stage1Player.GetComponent<GnrtBox>().InvokeGnrt();
        
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


}
