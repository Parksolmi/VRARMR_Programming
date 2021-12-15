using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        
    }

    void Update()
    {
        isSuccess = this.gameObject.GetComponent<Mng_Score>().GetIsSuccess();
        isFail = this.gameObject.GetComponent<Mng_Score>().GetIsFail();

        //성공
        if (isSuccess)
        {
            //포털 생성 멈춤
            player.GetComponent<GnrtPortal>().StopGnrt();
            //생성된 child지우기
            Destroy(GameObject.Find("Child(Clone)"));

            //ReStart버튼 활성화
            reStartBtn.SetActive(true);

            //성공 여부 false로 바꾸기
            this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
        }
        //실패
        else if (isFail)
        {
            //포털 생성 멈춤
            player.GetComponent<GnrtPortal>().StopGnrt();
            //생성된 child지우기
            Destroy(GameObject.Find("Child(Clone)"));

            //다시하기 버튼
            replayBtn.SetActive(true);

            //실패 여부 false로 바꾸기
            this.gameObject.GetComponent<Mng_Score>().SetIsFail(false);
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
        //게임 시작 전 score, goal변수 설정
        this.gameObject.GetComponent<Mng_Score>().SetScore(0);
        this.gameObject.GetComponent<Mng_Score>().SetGoal(15);

        //결과 메세지 지우기
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //버튼 지우기
        replayBtn.SetActive(false);

        //타이머 다시 설정
        this.gameObject.GetComponent<Mng_Score>().SetTimer();

        //포털 생성 함수 다시 호출
        player.GetComponent<GnrtPortal>().Invoke("StartGnrt", 2);
    }
}
