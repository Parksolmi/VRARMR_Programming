using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//스테이지 3 관리 함수
public class Mng_Stage3 : MonoBehaviour
{
    //플레이어 게임 오브젝트
    public GameObject player;

    //버튼
    //게임 성공 시 - 처음으로 넘어가는 버튼
    public GameObject reStartBtn;
    //게임 실패 시 - Replay버튼
    public GameObject replayBtn;

    //게임 종료 조건
    bool isSuccess;
    bool isFail;

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
            //reStart버튼이 활성화되어 있지 않다면
            if (reStartBtn.activeSelf == false)
            {
                //포털 생성 멈춤
                player.GetComponent<GnrtPortal>().StopGnrt();

                //ReStart버튼 활성화
                reStartBtn.SetActive(true);

                //성공 여부 false로 바꾸기
                this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
            }
        }
        //실패
        else if (isFail)
        {
            //replay버튼이 활성화 되어 있지 않다면
            if (replayBtn.activeSelf == false)
            {
                //포털 생성 멈춤
                player.GetComponent<GnrtPortal>().StopGnrt();

                //다시하기 버튼
                replayBtn.SetActive(true);

                //실패 여부 false로 바꾸기
                this.gameObject.GetComponent<Mng_Score>().SetIsFail(false);
            }
        }

    }

    //버튼이벤트
    //처음으로 돌아가는 이벤트
    public void OnClickReStartBtn()
    {
        //Scene다시 로드하기
        SceneManager.LoadScene("SantaGame");
        //결과 메세지 지우기
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;
        //버튼 지우기
        reStartBtn.SetActive(false);
    }

    //Replay버튼 이벤트
    public void OnClickReplayBtn()
    {
        //점수 초기화
        this.gameObject.GetComponent<Mng_Score>().SetScore(0);

        //결과 메세지 지우기
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //타이머 다시 설정
        this.gameObject.GetComponent<Mng_Score>().SetTimer();

        //포털 생성 함수 다시 호출
        player.GetComponent<GnrtPortal>().Invoke("StartGnrt", 2);
        //child 다시 생성
        player.GetComponent<GnrtChild>().StartCoroutine("GenerateChild");

        //bgm 다시 재생
        bgm.Play();

        //버튼 지우기
        replayBtn.SetActive(false);
    }
}