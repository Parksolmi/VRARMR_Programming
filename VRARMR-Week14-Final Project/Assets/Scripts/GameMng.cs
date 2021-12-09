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

    public Text startMsg; //���� �޼����� ������ ����

    public SantaIdle playerIdle; //�÷��̾� ��ü : ó�� ���� �� �� �÷��̾�
    public Santa1Ctrl stage1Player; //�÷��̾� ��ü : �������� 1 �÷��̾�

    public GameObject startBtn; //���� ��ư�� ������ ����

    private void Update()
    {
        if (gameState == GameState.Ready)
        {
            if (playerIdle.isDetected)
            {
                if (startBtn.activeSelf == false)
                {
                    startBtn.SetActive(true);
                    startMsg.text = "Ȯ�εǼ̽��ϴ�";
                }
            }
            else
            {
                if (startBtn.activeSelf)
                {
                    startBtn.SetActive(false);
                    startMsg.text = "��Ÿ��ȸ ȸ������ �������ּ���";
                }
            }
        }
    }

    //���� ��ư ������ �� �̺�Ʈ
    public void OnClickStartBtn()
    {
        //���� �������� �ѱ��
        gameState = GameState.Stage1;
        //�÷��̾� ��ü
        playerIdle.setActiveFalse();
        stage1Player.setActiveTrue();
        //�޼��� �����
        startMsg.text = null;
        //��ư �����
        startBtn.SetActive(false);
    }

}
