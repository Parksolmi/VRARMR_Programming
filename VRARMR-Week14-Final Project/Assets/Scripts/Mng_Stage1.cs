using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_Stage1 : MonoBehaviour
{
    //�÷��̾� ���� ������Ʈ
    public GameObject player;

    //��ư
    //���� ���� �� - Stage2�� �Ѿ�� ��ư
    public GameObject stage2Btn;
    //���� ���� �� - Replay��ư
    public GameObject replayBtn;

    //���� ���� ����
    bool isSuccess;
    bool isFail;

    //Stage3 ���ӿ�����Ʈ
    public GameObject stage2;

    void Start()
    {
        //���� ���� �� score, goal���� ����
        Mng_Score.instance.SetScore(5);
        Mng_Score.instance.SetGoal(15);
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
            stage2Btn.SetActive(true);
            Mng_Score.instance.SetIsStartbtnClicked(false);

            //���� ���� false�� �ٲٱ�
            Mng_Score.instance.SetIsSuccess(false);
        }
        //����
        else if (isFail)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().CancelInvoke("GenerateBox");
            //�ٽ��ϱ� ��ư
            replayBtn.SetActive(true);
            Mng_Score.instance.SetIsStartbtnClicked(false);

            //���� ���� false�� �ٲٱ�
            Mng_Score.instance.SetIsFail(false);
        }
    }

    //��ư�̺�Ʈ
    //Stage2�� �Ѿ�� ��ư �̺�Ʈ
    public void OnClickStage2Btn()
    {
        //�������� ����
        this.gameObject.SetActive(false);
        stage2.SetActive(true);
        //��� �޼��� �����
        Mng_Score.instance.resultText.text = null;
        //��ư �����
        stage2Btn.SetActive(false);
        //�ڽ� ���� �ٽ� ����
        //player.GetComponent<GnrtBox>().InvokeGnrt();
    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� ���� �� score, goal���� ����
        Mng_Score.instance.SetScore(5);
        Mng_Score.instance.SetGoal(15);

        //��� �޼��� �����
        Mng_Score.instance.resultText.text = null;

        //��ư �����
        replayBtn.SetActive(false);

        //�ڽ� ���� �ٽ� ����
        player.GetComponent<GnrtBox>().InvokeGnrt();

        //���� ���� true�� ����
        Mng_Score.instance.SetIsStartbtnClicked(true);
    }

}
