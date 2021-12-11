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
    public Santa2Ctrl stage2Player; //�÷��̾� ��ü : �������� 2 �÷��̾�

    public GameObject gun; //�� ������Ʈ �����ϴ� ����

    public GameObject backGround; //��� ������Ʈ�� ������ ����

    public GameObject startBtn; //���� ��ư�� ������ ����

    //�ڽ� ������Ʈ���� �浹 ���θ� �����ϴ� ����
    private bool isCollisionP; //���� ���ڿ��� �浹 ����
    private bool isCollisionB; //���� ���ڿ��� �浹 ����

    //������ �����ߴ��� ���θ� �����ϴ� ����
    private bool isStart = false;

    //���� ���� ���� ����
    private int score; //����
    private int goal; //��ǥ ���� : ������ ȹ���ؾ� �ϴ� ����

    //���� ���� �޼���
    public Text scoreMsg; //���� �����ִ� �޼���
    public Text goalMsg; //���� �����ִ� �޼���
    public Text resultMsg; //��� �����ִ� �޼���

    //��������2�� �Ѿ�� ��ư
    public GameObject stage2Btn;
    //�ٽ� �����ϱ� ��ư
    public GameObject replayBtn;

    private void Update()
    {
        //Ready������ �� ����
        if (gameState == GameState.Ready)
        {
            //�ʿ� ���� ��ư ��Ȱ��ȭ
            stage2Btn.SetActive(false);
            replayBtn.SetActive(false);

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

        //Stage1
        if (gameState == GameState.Stage1)
        {
            if(!isStart)
            {
                //���� ���� �� score, goal���� ����
                score = 5;
                goal = 15;

                scoreMsg.text = "Present " + score;
                goalMsg.text = "Goal " + goal;

                isStart = true;
            }
            else
            {
                //�ڽ��� �浹 �� Score ���� ����
                if (isCollisionP) //���� ���ڿ� �浹�� ���
                {
                    PlusScore();
                    isCollisionP = false;
                }
                if (isCollisionB) //���� ���ڿ� �浹�� ���
                {
                    MinusScore();
                    isCollisionB = false;
                }

                //���� ���� ����
                //����
                if (score >= goal)
                {
                    resultMsg.text = "Success!";
                    //�ڽ� ���� ����
                    stage1Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //��������2�� �Ѿ�� ��ư
                    stage2Btn.SetActive(true);
                }
                //����
                if (score < 0)
                {
                    resultMsg.text = "Fail!";
                    //�ڽ� ���� ����
                    stage1Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //�ٽ��ϱ� ��ư
                    replayBtn.SetActive(true);
                }
            }
        }

        
        //Stage2
        if (gameState == GameState.Stage2)
        {
            if (!isStart)
            {
                //���� ���� �� score, goal���� ����
                score = 10;
                goal = 20;

                scoreMsg.text = "Present " + score;
                goalMsg.text = "Goal " + goal;

                isStart = true;
            }
            else
            {
                //�ڽ��� �浹 �� Score ���� ����
                if (isCollisionP) //���� ���ڿ� �浹�� ���
                {
                    PlusScore();
                    isCollisionP = false;
                }
                if (isCollisionB) //���� ���ڿ� �浹�� ���
                {
                    MinusScore();
                    isCollisionB = false;
                }

                //���� ���� ����
                //����
                if (score >= goal)
                {
                    resultMsg.text = "Success!";
                    //�ڽ� ���� ����
                    stage2Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //��������2�� �Ѿ�� ��ư
                    //stage2Btn.SetActive(true);
                }
                //����
                if (score < 0)
                {
                    resultMsg.text = "Fail!";
                    //�ڽ� ���� ����
                    stage2Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //�ٽ��ϱ� ��ư
                    //replayBtn.SetActive(true);
                }
            }
        }
        
    }

    //gameState��ȯ�ϴ� �Լ�
    public string GetGameState()
    {
        return gameState.ToString();
    }

    //��ư �̺�Ʈ
    //���� ��ư ������ �� �̺�Ʈ
    public void OnClickStartBtn()
    {
        //���� �������� �ѱ��
        gameState = GameState.Stage1;
        //�÷��̾� ��ü
        playerIdle.setActiveFalse();
        stage1Player.setActiveTrue();
        //���Ȱ��ȭ
        backGround.SetActive(true);
        //�޼��� �����
        startMsg.text = null;
        //��ư �����
        startBtn.SetActive(false);
    }

    //Stage2�� �Ѿ�� ��ư �̺�Ʈ
    public void OnClickStage2Btn()
    {
        //���� �������� �ѱ��
        gameState = GameState.Stage2;
        //�÷��̾� ��ü
        stage1Player.setActiveFalse();
        stage2Player.setActiveTrue();
        //�� ������Ʈ Ȱ��ȭ
        gun.SetActive(true);
        //��� �޼��� �����
        resultMsg.text = null;
        //��ư �����
        stage2Btn.SetActive(false);
        //isStart ���� ����
        isStart = false;
    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� ���� �� score, goal���� ����
        score = 5;
        goal = 15;

        scoreMsg.text = "Present " + score;
        goalMsg.text = "Goal " + goal;

        //�ڽ� ���� �ٽ� ����
        stage1Player.GetComponent<GnrtBox>().InvokeRepeating("GenerateBox", 3, Random.Range(1, 3));

        //��� �޼��� �����
        resultMsg.text = null;
        //��ư �����
        replayBtn.SetActive(false);
    }

    //�浹 ���� ����
    public void SetIsCollisionP(bool collision)
    {
        isCollisionP = collision; 
    }
    public void SetIsCollisionB(bool collision)
    {
        isCollisionB = collision;
    }

    //��������1 score ���� �Լ�
    public void PlusScore()
    {
        score++;
        scoreMsg.text = "Present " + score;
    }
    public void MinusScore()
    {
        score -= 3;
        scoreMsg.text = "Present " + score;
    }
    //Score��ȯ �Լ�
    public int GetScore()
    {
        return score;
    }
    //goal��ȯ �Լ�
    public int GetGaol()
    {
        return goal;
    }

}
