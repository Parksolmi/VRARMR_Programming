using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mng_Start : MonoBehaviour
{
    public SantaIdle player; //�÷��̾� ��ü : ó�� ���� �� �� �÷��̾�

    public GameObject startBtn; //���� ��ư�� ������ ����

    public Text startMsg; //���� �޼����� ������ ����

    public GameObject stage1; //���� �������� : stage1

    void Start()
    {

    }

    void Update()
    {
        if (player.isDetected) //�÷��̾� ��ü�� �����Ǿ��� ��
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

    //��ư �̺�Ʈ
    //���� ��ư ������ �� �̺�Ʈ
    public void OnClickStartBtn()
    {
        //�������� ����
        this.gameObject.SetActive(false);
        stage1.SetActive(true);
        //�޼��� �����
        startMsg.text = null;
        //��ư �����
        startBtn.SetActive(false);
    }
}
