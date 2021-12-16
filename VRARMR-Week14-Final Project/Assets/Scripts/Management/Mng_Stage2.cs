using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이지 2 관리 클래스
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

    //bgm 오디오
    AudioSource bgm;

    void Start()
    {
        //오디오 컴포넌트 가져오기
        bgm = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Score관리 클래스에서 게임 종료에 대한 변수 가져오기
        isSuccess = this.gameObject.GetComponent<Mng_Score>().GetIsSuccess();
        isFail = this.gameObject.GetComponent<Mng_Score>().GetIsFail();

        //성공
        if (isSuccess)
        {
            //박스 생성 멈춤
            player.GetComponent<GnrtBox>().StopGnrt();
            //Enemy생성 멈춤
            player.GetComponent<GnrtEnemy>().StopGnrt();
            //아이템 생성 멈춤
            player.GetComponent<GnrtTimeItem>().StopGnrt();

            //생성 되어 있는 상자 오브젝트 지우기
            Destroy(GameObject.Find("Present2(Clone)"));
            Destroy(GameObject.Find("WoodBox(Clone)"));
            Destroy(GameObject.Find("Present2OnGrnd(Clone)"));

            //생성되어 있는 Enemy 지우기
            Destroy(GameObject.Find("Stage2Enemy(Clone)"));

            //스테이지2로 넘어가는 버튼
            stage3Btn.SetActive(true);

            //성공 여부 false로 바꾸기
            this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
        }

        //실패
        else if (isFail)
        {
            //박스 생성 멈춤
            player.GetComponent<GnrtBox>().StopGnrt();
            //Enemy생성 멈춤
            player.GetComponent<GnrtEnemy>().StopGnrt();
            //아이템 생성 멈춤
            player.GetComponent<GnrtTimeItem>().StopGnrt();

            //생성 되어 있는 상자 오브젝트 지우기
            Destroy(GameObject.Find("Present2(Clone)"));
            Destroy(GameObject.Find("WoodBox(Clone)"));
            Destroy(GameObject.Find("Present2OnGrnd(Clone)"));

            //생성되어 있는 Enemy 지우기
            Destroy(GameObject.Find("Stage2Enemy(Clone)"));

            //다시하기 버튼
            replayBtn.SetActive(true);

            //실패 여부 false로 바꾸기
            this.gameObject.GetComponent<Mng_Score>().SetIsFail(false);
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
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;
        //버튼 지우기
        stage3Btn.SetActive(false);
    }

    //Replay버튼 이벤트
    public void OnClickReplayBtn()
    {
        //점수 초기화
        this.gameObject.GetComponent<Mng_Score>().SetScore(0);

        //결과 메세지 지우기
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //버튼 지우기
        replayBtn.SetActive(false);

        //타이머 다시 설정
        this.gameObject.GetComponent<Mng_Score>().SetTimer();

        //박스 생성 다시 시작
        player.GetComponent<GnrtBox>().StartGnrt();
        //Enemy생성 다시 시작
        player.GetComponent<GnrtEnemy>().StartGnrt();
        //아이템 생성 다시 시작
        player.GetComponent<GnrtTimeItem>().StartGnrt();

        //bgm 다시 재생
        bgm.Play();
    }

}
