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

    //���÷��� ��ư
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
                    stateMsg.text = "���� ��ư�� �����ּ���";
                }
            }

            else
            {
                if (objStartBtn.activeSelf)
                {
                    objStartBtn.SetActive(false);
                    stateMsg.text = "ī�带 �νĽ����ּ���";
                }
            }
        }
    }

    public void OnClickStart()
    {
        gameState = GameState.Battle;
        stateMsg.text = "�ֻ����� ���� ���ϱ�";

        objStartBtn.SetActive(false);
        StartCoroutine(RollTheDices());
    }

    //IEnumerator => coroutine�Լ� �νĿ� �ʿ��� �����
    IEnumerator RollTheDices()
    {
        int dicePlayer = 0;
        int diceMonster = 0;

        for(int i=0; i<30; i++)
        {
            dicePlayer = Random.Range(1, 7);
            diceMonster = Random.Range(1, 7);

            objPlayer.infoTM.text = "�ֻ��� : " + dicePlayer;
            objMonster.infoTM.text = "�ֻ��� : " + diceMonster;

            //yield return null;
            yield return new WaitForSeconds(0.1f); //0.1�� ���� ���(Update�Լ�����)
        }

        if(dicePlayer > diceMonster)
        {
            stateMsg.text = objPlayer.objName + " ����";
            StartCoroutine(StartBattle(objPlayer, objMonster));
        }
        else if (dicePlayer < diceMonster)
        {
            stateMsg.text = objMonster.objName + " ����";
            StartCoroutine(StartBattle(objMonster, objPlayer));
        }
        else
        {
            stateMsg.text = "���º� - �ٽ��ϱ�";

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
            stateMsg.text = firstTurn.objName + "����";

            //�ִϸ��̼�
            float aniLen = firstTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            firstTurn.PlayAnimation("Idle");

            //����
            secondHP -= firstTurn.atk;
            secondTurn.infoTM.text = secondTurn.objName + "\n HP:" + secondHP;

            if(secondHP <=0)
            {
                stateMsg.text = firstTurn.objName + "��(��) �¸��Ͽ����ϴ�.";
                break;
            }

            yield return new WaitForSeconds(1.0f);
            

            //���� ��
            stateMsg.text = secondTurn.objName + "����";

            //�ִϸ��̼�
            aniLen = secondTurn.PlayAnimation("Attack");
            yield return new WaitForSeconds(aniLen);
            secondTurn.PlayAnimation("Idle");

            //����
            firstHP -= secondTurn.atk;
            firstTurn.infoTM.text = firstTurn.objName + "\n HP:" + firstHP;

            if(firstHP<=0)
            {
                stateMsg.text = secondTurn.objName + "��(��) �¸��Ͽ����ϴ�.";
                break;
            }
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);
        //���÷��� ��ư
        objReplayBtn.SetActive(true);
    }

    public void OnClickReplay()
    {
        gameState = GameState.Ready;
        stateMsg.text = "ī�带 �νĽ����ּ���.";

        objPlayer.InitInfo();
        objMonster.InitInfo();

        objReplayBtn.SetActive(false);
    }
}
