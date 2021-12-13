using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mng_Start : MonoBehaviour
{
    public SantaIdle player; //플레이어 객체 : 처음 시작 할 때 플레이어

    public GameObject startBtn; //시작 버튼을 저장할 변수

    public Text startMsg; //시작 메세지를 저장할 변수

    public GameObject stage1; //다음 스테이지 : stage1

    void Start()
    {

    }

    void Update()
    {
        if (player.isDetected) //플레이어 객체가 감지되었을 때
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

    //버튼 이벤트
    //시작 버튼 눌렀을 때 이벤트
    public void OnClickStartBtn()
    {
        //스테이지 변경
        this.gameObject.SetActive(false);
        stage1.SetActive(true);
        //메세지 지우기
        startMsg.text = null;
        //버튼 지우기
        startBtn.SetActive(false);
    }
}
