using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2���� ���� ���ڰ� time-out�Ǿ� ����������
//���� ��Ÿ(Enemy Santa)�� ���İ��� ���������� �˻��ϴ� Ŭ����
public class CheckTimeOut : MonoBehaviour
{
    //�������� ���� �� ���� ������Ʈ
    GameObject stage;

    //Ÿ�Ӿƿ� ���θ� �����ϴ� ����
    bool isTimeOut;

    //getter
    public bool GetIsTimeOut()
    {
        return isTimeOut;
    }

    void Start()
    {
        //�������� ���� ����
        stage = GameObject.FindGameObjectWithTag("Stage2");

        //Ÿ�Ӿƿ� true�� ����
        isTimeOut = true;

        //�ڷ�ƾ �Լ� ȣ�� - destroy �Ŀ� isTimeOut���θ� �˻��ϱ� ���ؼ�
        StartCoroutine(PlusScore());
    }

    //�浹 �˻�
    private void OnTriggerEnter(Collider other)
    {
        //Enemy Santa�� �浹 �� ��� Ÿ�� �ƿ����� ����� ���� �ƴϹǷ�
        //isTimeOut���� false�� ����
        if (other.tag == "EnemySanta")
        {
            isTimeOut = false;
        }
    }

    //���� ȹ�� �Լ�
    IEnumerator PlusScore()
    {
        //15�� �Ŀ� �˻�
        yield return new WaitForSeconds(15f);

        //Ÿ�Ӿƿ��� �´ٸ�
        if (isTimeOut)
        {
            //������ �������Ƿ� 1�� ȹ��
            stage.GetComponent<Mng_Score>().AddScore(1);
        }

        //������Ʈ ����
        Destroy(this.gameObject);
    }
}
