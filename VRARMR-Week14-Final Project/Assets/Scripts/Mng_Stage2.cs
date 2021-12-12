using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_Stage2 : MonoBehaviour
{
    //플레이어 게임 오브젝트
    public GameObject player;

    //버튼
    //게임 성공 시 - Stage3로 넘어가는 버튼
    public GameObject stage3Btn;
    //게임 실패 시 - Replay버튼
    public GameObject replayBtn;

    //게임 종료 조건
    bool isSuccess;
    bool isFail;

    //Stage3 게임오브젝트
    public GameObject stage3;

    void Start()
    {
        //시작 여부 true로 바꾸기
        Mng_Score.instance.SetIsStartbtnClicked(true);
        //게임 시작 전 score, goal변수 설정
        Mng_Score.instance.SetScore(10);
        Mng_Score.instance.SetGoal(30);
    }

    void Update()
    {
        isSuccess = Mng_Score.instance.GetIsSuccess();
        isFail = Mng_Score.instance.GetIsFail();

        //성공
        if (isSuccess)
        {
            //박스 생성 멈춤
            player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
            //스테이지2로 넘어가는 버튼
            stage3Btn.SetActive(true);
        }
        //실패
        else if (isFail)
        {
            //박스 생성 멈춤
            player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
            //다시하기 버튼
            replayBtn.SetActive(true);
        }

    }

    //버튼이벤트
    //Stage3로 넘어가는 버튼 이벤트
    public void OnClickStage3Btn()
    {
        //스테이지 변경
        this.gameObject.SetActive(false);
        stage3.SetActive(true);
        //결과 메세지 지우기
        Mng_Score.instance.resultText.text = null;
        //버튼 지우기
        stage3Btn.SetActive(false);
    }

    //Replay버튼 이벤트
    public void OnClickReplayBtn()
    {
        //게임 시작 전 score, goal변수 설정
        Mng_Score.instance.SetScore(10);
        Mng_Score.instance.SetGoal(30);

        //결과 메세지 지우기
        Mng_Score.instance.resultText.text = null;

        //버튼 지우기
        replayBtn.SetActive(false);
    }
}
