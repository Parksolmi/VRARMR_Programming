using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Ready,
    Stage1,
    Stage2,
    Stage3
}

public class GameMng : MonoBehaviour
{
    public GameState gameState = GameState.Ready;

    public Text startMsg; //시작 메세지를 저장할 변수

    public SantaIdle playerIdle; //플레이어 객체 : 처음 시작 할 때 플레이어
    public Santa1Ctrl stage1Player; //플레이어 객체 : 스테이지 1 플레이어

    public GameObject startBtn; //시작 버튼을 저장할 변수

    private void Update()
    {
        if (gameState == GameState.Ready)
        {
            if (playerIdle.isDetected)
            {
                if (startBtn.activeSelf == false)
                {
                    startBtn.SetActive(true);
                    startMsg.text = "확인되셨습니다";
                }
            }
            else
            {
                if (startBtn.activeSelf)
                {
                    startBtn.SetActive(false);
                    startMsg.text = "산타협회 회원증을 제시해주세요";
                }
            }
        }
    }

    //시작 버튼 눌렀을 때 이벤트
    public void OnClickStartBtn()
    {
        //게임 스테이지 넘기기
        gameState = GameState.Stage1;
        //플레이어 교체
        playerIdle.setActiveFalse();
        stage1Player.setActiveTrue();
        //메세지 지우기
        startMsg.text = null;
        //버튼 지우기
        startBtn.SetActive(false);
    }

}
