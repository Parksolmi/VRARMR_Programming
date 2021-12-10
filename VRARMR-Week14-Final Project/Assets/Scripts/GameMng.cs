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


    private void Start()
    {
        
    }


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

        //Stage1���� ���� ���� ����
        if (gameState == GameState.Stage1)
        {
            if(!isStart)
            {
                //���� ���� �� score, goal���� ����
                score = 0;
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
                    resultMsg.text = "Success";
                    stage1Player.GetComponent<GnrtBox>().enabled = false;
                    //��������2�� �Ѿ�� ��ư

                }
                //����
                if (score < 0)
                {
                    resultMsg.text = "Fail";
                    stage1Player.GetComponent<GnrtBox>().enabled = false;
                    //�ٽ��ϱ� ��ư

                }
            }
        }
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
        scoreMsg.text = "Score " + score;
    }
    public void MinusScore()
    {
        score -= 3;
        scoreMsg.text = "Score " + score;
    }

}
