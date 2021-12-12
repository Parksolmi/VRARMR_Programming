using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_Stage1 : MonoBehaviour
{
    //플레이어 게임 오브젝트
    public GameObject player;

    //버튼
    //게임 성공 시 - Stage2로 넘어가는 버튼
    public GameObject stage2Btn;
    //게임 실패 시 - Replay버튼
    public GameObject replayBtn;

    //게임 종료 조건
    bool isSuccess;
    bool isFail;

    //Stage3 게임오브젝트
    public GameObject stage2;

    void Start()
    {
        //게임 시작 전 score, goal변수 설정
        Mng_Score.instance.SetScore(5);
        Mng_Score.instance.SetGoal(15);
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
            stage2Btn.SetActive(true);
            Mng_Score.instance.SetIsStartbtnClicked(false);

            //성공 여부 false로 바꾸기
            Mng_Score.instance.SetIsSuccess(false);
        }
        //실패
        else if (isFail)
        {
            //박스 생성 멈춤
            player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
            //다시하기 버튼
            replayBtn.SetActive(true);
            Mng_Score.instance.SetIsStartbtnClicked(false);

            //실패 여부 false로 바꾸기
            Mng_Score.instance.SetIsFail(false);
        }
    }

    //버튼이벤트
    //Stage2로 넘어가는 버튼 이벤트
    public void OnClickStage2Btn()
    {
        //스테이지 변경
        this.gameObject.SetActive(false);
        stage2.SetActive(true);
        //결과 메세지 지우기
        Mng_Score.instance.resultText.text = null;
        //버튼 지우기
        stage2Btn.SetActive(false);
        //박스 생성 다시 시작
        //player.GetComponent<GnrtBox>().InvokeGnrt();
    }

    //Replay버튼 이벤트
    public void OnClickReplayBtn()
    {
        //게임 시작 전 score, goal변수 설정
        Mng_Score.instance.SetScore(5);
        Mng_Score.instance.SetGoal(15);

        //결과 메세지 지우기
        Mng_Score.instance.resultText.text = null;

        //버튼 지우기
        replayBtn.SetActive(false);

        //박스 생성 다시 시작
        player.GetComponent<GnrtBox>().InvokeGnrt();

        //시작 여부 true로 설정
        Mng_Score.instance.SetIsStartbtnClicked(true);
    }

}
