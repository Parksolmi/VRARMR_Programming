using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        
    }

    void Update()
    {
        isSuccess = this.gameObject.GetComponent<Mng_Score>().GetIsSuccess();
        isFail = this.gameObject.GetComponent<Mng_Score>().GetIsFail();

        //����
        if (isSuccess)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().StopGnrt();

            //���� �Ǿ� �ִ� �ڽ� �����
            Destroy(GameObject.Find("Present1(Clone)"));
            Destroy(GameObject.Find("WoodBox(Clone)"));

            //��������2�� �Ѿ�� ��ư
            stage2Btn.SetActive(true);

            //���� ���� false�� �ٲٱ�
            this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
        }
        //����
        else if (isFail)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().StopGnrt();

            //���� �Ǿ� �ִ� �ڽ� �����
            Destroy(GameObject.Find("Present1(Clone)"));
            Destroy(GameObject.Find("WoodBox(Clone)"));

            //�ٽ��ϱ� ��ư
            replayBtn.SetActive(true);

            //���� ���� false�� �ٲٱ�
            this.gameObject.GetComponent<Mng_Score>().SetIsFail(false);
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
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;
        //��ư �����
        stage2Btn.SetActive(false);
    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� ���� �� score, goal���� ����
        this.gameObject.GetComponent<Mng_Score>().SetScore(0);
        this.gameObject.GetComponent<Mng_Score>().SetGoal(15);

        //��� �޼��� �����
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //��ư �����
        replayBtn.SetActive(false);

        //Ÿ�̸� �ٽ� ����
        this.gameObject.GetComponent<Mng_Score>().SetTimer();

        //�ڽ� ���� �ٽ� ����
        player.GetComponent<GnrtBox>().StartGnrt();
    }

}
