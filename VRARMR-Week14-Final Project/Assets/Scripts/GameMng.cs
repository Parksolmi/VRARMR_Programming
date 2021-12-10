using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���� ����(�� ��������)�� �˷��ִ� ����
public enum GameState
{
    Ready, //�غ� : ���� ���� ��
    Stage1, //�������� 1
    Stage2, //�������� 2
    Stage3 //�������� 3
}

//���� ������ ���� ManagementŬ����
public class GameMng : MonoBehaviour
{
    //���� �� : ���� �������� Ready�� ����
    public GameState gameState = GameState.Ready;

    public Text startMsg; //���� �޼����� ������ ����

    public SantaIdle playerIdle; //�÷��̾� ��ü : ó�� ���� �� �� �÷��̾�
    public Santa1Ctrl stage1Player; //�÷��̾� ��ü : �������� 1 �÷��̾�

    public GameObject startBtn; //���� ��ư�� ������ ����
    
    public GameObject box; //���� ������Ʈ�� ������ ����

    private void Update()
    {
        //Ready������ �� ����
        if (gameState == GameState.Ready)
        {
            if (playerIdle.isDetected) //�÷��̾� ��ü�� �����Ǿ��� ��
            {
                //��ŸƮ ��ư�� Ȱ��ȭ�Ǿ����� �ʴٸ�
                if (startBtn.activeSelf == false)
                {
                    //��ŸƮ ��ư Ȱ��ȭ ��Ű��
                    startBtn.SetActive(true);
                    //Ȯ�� �Ǿ����� �˸��� �޼��� ����ϱ�
                    startMsg.text = "Ȯ�εǼ̽��ϴ�";
                }
            }
            else //�÷��̾� ��ü�� �������� �ʾ��� ��
            {
                //��ŸƮ ��ư�� Ȱ��ȭ �Ǿ� �ִٸ�
                if (startBtn.activeSelf)
                {
                    //��ŸƮ ��ư�� ������ �ʵ��� ��Ȱ��ȭ ��Ű��
                    startBtn.SetActive(false);
                    //ī�� �ν��� ���� �޼��� ����ϱ�
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
        //�ڽ� ������Ʈ Ȱ��ȭ
        box.SetActive(true);
    }


}
