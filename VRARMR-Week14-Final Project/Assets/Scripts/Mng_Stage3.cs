using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng_Stage3 : MonoBehaviour
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
            //Enemy���� ����
            player.GetComponent<GnrtEnemy>().StopGnrt();
            //������ ���� ����
            player.GetComponent<GnrtTimeItem>().StopGnrt();

            //�����Ǿ� �ִ� �ڽ� �����
            Destroy(GameObject.Find("Present2(Clone)"));
            Destroy(GameObject.Find("WoodBox(Clone)"));
            Destroy(GameObject.Find("Present2OnGrnd(Clone)"));

            //�����Ǿ� �ִ� Enemy �����
            Destroy(GameObject.Find("Stage2Enemy(Clone)"));

            //��������2�� �Ѿ�� ��ư
            stage3Btn.SetActive(true);

            //���� ���� false�� �ٲٱ�
            this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
        }
        //����
        else if (isFail)
        {
            //�ڽ� ���� ����
            player.GetComponent<GnrtBox>().StopGnrt();
            //Enemy���� ����
            player.GetComponent<GnrtEnemy>().StopGnrt();
            //������ ���� ����
            player.GetComponent<GnrtTimeItem>().StopGnrt();

            //�����Ǿ� �ִ� �ڽ� �����
            Destroy(GameObject.Find("Present2(Clone)"));
            Destroy(GameObject.Find("WoodBox(Clone)"));
            Destroy(GameObject.Find("Present2OnGrnd(Clone)"));

            //�����Ǿ� �ִ� Enemy �����
            Destroy(GameObject.Find("Stage2Enemy(Clone)"));

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
        this.gameObject.GetComponent<Mng_Score>().SetScore(0);
        this.gameObject.GetComponent<Mng_Score>().SetGoal(20);

        //��� �޼��� �����
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //��ư �����
        replayBtn.SetActive(false);

        //Ÿ�̸� �ٽ� ����
        this.gameObject.GetComponent<Mng_Score>().SetTimer();

        //�ڽ� ���� �ٽ� ����
        player.GetComponent<GnrtBox>().StartGnrt();
        //Enemy���� �ٽ� ����
        player.GetComponent<GnrtEnemy>().StartGnrt();
        //������ ���� �ٽ� ����
        player.GetComponent<GnrtTimeItem>().StartGnrt();
    }

}
