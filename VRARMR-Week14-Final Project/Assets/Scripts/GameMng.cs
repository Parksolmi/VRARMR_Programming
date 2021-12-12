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

    //��������2�� �Ѿ�� ��ư
    public GameObject stage2Btn;
    //�ٽ� �����ϱ� ��ư
    public GameObject replayBtn;

    //���� ���� ���� ����
    bool isSuccess;
    bool isFail;

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

        //���� ���� ����
        isSuccess = ScoreMng.instance.GetIsSuccess();
        isFail = ScoreMng.instance.GetIsFail();

        //Stage1
        if (gameState == GameState.Stage1)
        {
            if(!isStart)
            {
                //���� ���� �� score, goal���� ����
                ScoreMng.instance.SetScore(5);
                ScoreMng.instance.SetGoal(15);
                
                isStart = true;
            }
            else
            {                
                //����
                if (isSuccess)
                {
                    //�ڽ� ���� ����
                    stage1Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //��������2�� �Ѿ�� ��ư
                    stage2Btn.SetActive(true);

                    ScoreMng.instance.SetIsSuccess(false);
                }
                //����
                else if (isFail)
                {
                    //�ڽ� ���� ����
                    stage1Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //�ٽ��ϱ� ��ư
                    replayBtn.SetActive(true);

                    ScoreMng.instance.SetIsFail(false);
                }
            }
        }

        
        //Stage2
        if (gameState == GameState.Stage2)
        {
            if (!isStart)
            {
                //���� ���� �� score, goal���� ����
                ScoreMng.instance.SetScore(10);
                ScoreMng.instance.SetGoal(30);

                isStart = true;

            }
            else
            {
                //���� ���� ����
                //����
                if (isSuccess)
                {
                    //�ڽ� ���� ����
                    stage2Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //��������2�� �Ѿ�� ��ư
                    //stage2Btn.SetActive(true);
                }
                //����
                else if (isFail)
                {
                    //�ڽ� ���� ����
                    stage2Player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
                    //�ٽ��ϱ� ��ư
                    //replayBtn.SetActive(true);
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
        //score text ����
        ScoreMng.instance.SetIsStartbtnClicked(true);
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
        ScoreMng.instance.resultText.text = null;
        //��ư �����
        stage2Btn.SetActive(false);
        //isStart ���� ����
        isStart = false;

        //�ڽ� ���� �ٽ� ����
        stage2Player.GetComponent<GnrtBox>().InvokeGnrt();

    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� ���� �� score, goal���� ����
        ScoreMng.instance.SetScore(5);
        ScoreMng.instance.SetGoal(15);

        //��� �޼��� �����
        ScoreMng.instance.resultText.text = null;

        //��ư �����
        replayBtn.SetActive(false);
        
        //�ڽ� ���� �ٽ� ����
        stage1Player.GetComponent<GnrtBox>().InvokeGnrt();
        
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


}
