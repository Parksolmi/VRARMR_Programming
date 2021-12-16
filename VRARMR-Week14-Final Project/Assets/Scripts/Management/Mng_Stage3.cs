using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        bgm = GetComponent<AudioSource>();
    }

    void Update()
    {

        isSuccess = this.gameObject.GetComponent<Mng_Score>().GetIsSuccess();
        isFail = this.gameObject.GetComponent<Mng_Score>().GetIsFail();

        //����
        if (isSuccess)
        {
            if(reStartBtn.activeSelf == false)
            {
                //���� ���� ����
                player.GetComponent<GnrtPortal>().StopGnrt();

                //������ ���� �����
                Destroy(GameObject.Find("Portal1(Clone)"));
                Destroy(GameObject.Find("Portal2(Clone)"));
                //������ child�����
                Destroy(GameObject.Find("Child(Clone)"));
                Destroy(GameObject.Find("Child(Clone)"));
                Destroy(GameObject.Find("Child(Clone)"));

                //ReStart��ư Ȱ��ȭ
                reStartBtn.SetActive(true);

                //���� ���� false�� �ٲٱ�
                this.gameObject.GetComponent<Mng_Score>().SetIsSuccess(false);
            }           
        }
        //����
        else if (isFail)
        {
            if(replayBtn.activeSelf == false)
            {
                //���� ���� ����
                player.GetComponent<GnrtPortal>().StopGnrt();

                //������ ���� �����
                Destroy(GameObject.Find("Portal1(Clone"));
                Destroy(GameObject.Find("Portal2(Clone"));
                //������ child�����
                Destroy(GameObject.Find("Child(Clone)"));

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
