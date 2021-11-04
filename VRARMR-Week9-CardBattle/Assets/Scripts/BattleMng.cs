using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Ready, //0
    Battle, //1
    Result //2
}

public class BattleMng : MonoBehaviour
{
    public TrackObj objPlayer;
    public TrackObj objMonster;
    public Text stateMsg;
    public GameObject objStartBtn;

    public GameState gameState = GameState.Ready;

    //리플레이 버튼
    public GameObject objReplayBtn;

    void Update()
    {
        if (gameState == GameState.Ready)
        {
            if (objPlayer.isDetected && objMonster.isDetected)
            {
                if (objStartBtn.activeSelf == false)
                {
                    objStartBtn.SetActive(true);
                    stateMsg.text = "시작 버튼을 눌러주세요";
                }
            }

            else
            {
                if (objStartBtn.activeSelf)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "카드를 인식시켜주세요";
                }
            }
        }
    }

    public void OnClickStart()
    {
        gameState = GameState.Battle;
        stateMsg.text = "주사위로 선공 정하기";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }

    //IEnumerator => coroutine함수 인식에 필요한 예약어
    IEnumerator RollTheDices()
    {
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i=0; i<30; i++)
        {
            dicePlayer = Random.Range(1, 7);
            diceMonster = Random.Range(1, 7);

            objPlayer.infoTM.text = "주사위 : " + dicePlayer;
            objMonster.infoTM.text = "주사위 : " + diceMonster;

            //yield return null;
            yield return new WaitForSeconds(0.1f); //0.1초 동안 대기(Update함수실행)
        }

        if(dicePlayer > diceMonster)
        {
            stateMsg.text = objPlayer.objName + " 선공";
            StartCoroutine(StartBattle(objPlayer, objMonster));
        }
        else if (dicePlayer < diceMonster)
        {
            stateMsg.text = objMonster.objName + " 선공";
            StartCoroutine(StartBattle(objMonster, objPlayer));
        }
        else
        {
            stateMsg.text = "무승부 - 다시하기";

            yield return new WaitForSeconds(1.0f);
            StartCoroutine(RollTheDices());
        }
    }

    IEnumerator StartBattle(TrackObj firstTurn, TrackObj secondTurn)
    {
        yield return new WaitForSeconds(1.0f);

        int firstHP = firstTurn.hp;
        int secondHP = secondTurn.hp;

        firstTurn.infoTM.text = firstTurn.objName + "\n HP:" + firstHP;
        secondTurn.infoTM.text = secondTurn.objName + "\n HP:" + secondHP;

        while(true)
        {
            stateMsg.text = firstTurn.objName + "공격";

            //애니메이션
            float aniLen = firstTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            firstTurn.PlayAnimation("Idle");

            //공격
            secondHP -= firstTurn.atk;
            secondTurn.infoTM.text = secondTurn.objName + "\n HP:" + secondHP;

            if(secondHP <=0)
            {
                stateMsg.text = firstTurn.objName + "이(가) 승리하였습니다.";
                break;
            }

            yield return new WaitForSeconds(1.0f);
            

            //다음 턴
            stateMsg.text = secondTurn.objName + "공격";

            //애니메이션
            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            //공격
            firstHP -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP:" + firstHP;

            if(firstHP<=0)
            {
                stateMsg.text = secondTurn.objName + "이(가) 승리하였습니다.";
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);
        //리플레이 버튼
        objReplayBtn.SetActive(true);
    }

    public void OnClickReplay()
    {
        gameState = GameState.Ready;
        stateMsg.text = "카드를 인식시켜주세요.";

        objPlayer.InitInfo();
        objMonster.InitInfo();

        objReplayBtn.SetActive(false);
    }
}
