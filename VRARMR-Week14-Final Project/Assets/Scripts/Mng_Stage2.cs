using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_Stage2 : MonoBehaviour
{
    //�÷��̾� ���� ������Ʈ
    public GameObject player;

    //��ư
    //���� ���� �� - Stage3�� �Ѿ�� ��ư
    public GameObject stage3Btn;
    //���� ���� �� - Replay��ư
    public GameObject replayBtn;

    //���� ���� ����
    bool isSuccess;
    bool isFail;

    //Stage3 ���ӿ�����Ʈ
    public GameObject stage3;

    void Start()
    {
        //���� ���� true�� �ٲٱ�
        Mng_Score.instance.SetIsStartbtnClicked(true);
        //���� ���� �� score, goal���� ����
        Mng_Score.instance.SetScore(10);
        Mng_Score.instance.SetGoal(30);
    }

    void Update()
    {
        isSuccess = Mng_Score.instance.GetIsSuccess();
        isFail = Mng_Score.instance.GetIsFail();

        //����
        if (isSuccess)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
            //��������2�� �Ѿ�� ��ư
            stage3Btn.SetActive(true);
        }
        //����
        else if (isFail)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
            //�ٽ��ϱ� ��ư
            replayBtn.SetActive(true);
        }

    }

    //��ư�̺�Ʈ
    //Stage3�� �Ѿ�� ��ư �̺�Ʈ
    public void OnClickStage3Btn()
    {
        //�������� ����
        this.gameObject.SetActive(false);
        stage3.SetActive(true);
        //��� �޼��� �����
        Mng_Score.instance.resultText.text = null;
        //��ư �����
        stage3Btn.SetActive(false);
    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� ���� �� score, goal���� ����
        Mng_Score.instance.SetScore(10);
        Mng_Score.instance.SetGoal(30);

        //��� �޼��� �����
        Mng_Score.instance.resultText.text = null;

        //��ư �����
        replayBtn.SetActive(false);
    }
}
