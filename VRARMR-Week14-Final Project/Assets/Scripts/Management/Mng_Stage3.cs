using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�������� 3 ���� �Լ�
public class Mng_Stage3 : MonoBehaviour
{
    //�÷��̾� ���� ������Ʈ
    public GameObject player;

    //��ư
    //���� ���� �� - ó������ �Ѿ�� ��ư
    public GameObject reStartBtn;
    //���� ���� �� - Replay��ư
    public GameObject replayBtn;

    //���� ���� ����
    bool isSuccess;
    bool isFail;

    //bgm �����
    AudioSource bgm;

    void Start()
    {
        //����� ������Ʈ ��������
        bgm = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Score���� Ŭ�������� ���� ���ῡ ���� ���� ��������
        isSuccess = this.gameObject.GetComponent<Mng_Score>().GetIsSuccess();
        isFail = this.gameObject.GetComponent<Mng_Score>().GetIsFail();

        //����
        if (isSuccess)
        {
            //reStart��ư�� Ȱ��ȭ�Ǿ� ���� �ʴٸ�
            if (reStartBtn.activeSelf == false)
            {
                //���� ���� ����
                player.GetComponent<GnrtPortal>().StopGnrt();

                //ReStart��ư Ȱ��ȭ
                reStartBtn.SetActive(true);

                //���� ���� false�� �ٲٱ�
                this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
            }
        }
        //����
        else if (isFail)
        {
            //replay��ư�� Ȱ��ȭ �Ǿ� ���� �ʴٸ�
            if (replayBtn.activeSelf == false)
            {
                //���� ���� ����
                player.GetComponent<GnrtPortal>().StopGnrt();

                //�ٽ��ϱ� ��ư
                replayBtn.SetActive(true);

                //���� ���� false�� �ٲٱ�
                this.gameObject.GetComponent<Mng_Score>().SetIsFail(false);
            }
        }

    }

    //��ư�̺�Ʈ
    //ó������ ���ư��� �̺�Ʈ
    public void OnClickReStartBtn()
    {
        //Scene�ٽ� �ε��ϱ�
        SceneManager.LoadScene("SantaGame");
        //��� �޼��� �����
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;
        //��ư �����
        reStartBtn.SetActive(false);
    }

    //Replay��ư �̺�Ʈ
    public void OnClickReplayBtn()
    {
        //���� �ʱ�ȭ
        this.gameObject.GetComponent<Mng_Score>().SetScore(0);

        //��� �޼��� �����
        this.gameObject.GetComponent<Mng_Score>().resultText.text = null;

        //Ÿ�̸� �ٽ� ����
        this.gameObject.GetComponent<Mng_Score>().SetTimer();

        //���� ���� �Լ� �ٽ� ȣ��
        player.GetComponent<GnrtPortal>().Invoke("StartGnrt", 2);
        //child �ٽ� ����
        player.GetComponent<GnrtChild>().StartCoroutine("GenerateChild");

        //bgm �ٽ� ���
        bgm.Play();

        //��ư �����
        replayBtn.SetActive(false);
    }
}