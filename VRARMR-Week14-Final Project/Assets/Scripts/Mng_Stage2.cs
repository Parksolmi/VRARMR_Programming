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
        //���� ���� �� score, goal���� ����
        this.gameObject.GetComponent<Mng_Score>().SetScore(10);
        this.gameObject.GetComponent<Mng_Score>().SetGoal(30);
    }

    void Update()
    {
        isSuccess = this.gameObject.GetComponent<Mng_Score>().GetIsSuccess();
        isFail = this.gameObject.GetComponent<Mng_Score>().GetIsFail();

        //����
        if (isSuccess)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().StopCoroutine("GenerateBox");
            //��������2�� �Ѿ�� ��ư
            stage3Btn.SetActive(true);

            //���� ���� false�� �ٲٱ�
            this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
        }
        //����
        else if (isFail)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().StopCoroutine("GenerateBox");
            //�ٽ��ϱ� ��ư
            replayBtn.SetActive(true);

            //���� ���� false�� �ٲٱ�
            this.gameObject.GetComponent<Mng_Score>().SetIsFail(false);
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
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;
        //��ư �����
        stage3Btn.SetActive(false);
    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� ���� �� score, goal���� ����
        this.gameObject.GetComponent<Mng_Score>().SetScore(10);
        this.gameObject.GetComponent<Mng_Score>().SetGoal(30);

        //��� �޼��� �����
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //��ư �����
        replayBtn.SetActive(false);
    }
}
