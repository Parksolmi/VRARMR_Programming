using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2�� �����ϴ� ���� ������ ���� ���ڸ� �����ϴ� Ŭ����
public class GnrtPresentOnGrnd : MonoBehaviour
{
    //PresentOnGrnd ������ ���� �� ���ӿ�����Ʈ
    public GameObject presentOnGrnd;

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        //���� �浹�� ���
        if (other.gameObject.tag.Equals("Ground"))
        {
            //���� ������Ʈ�� �����ϱ�
            GeneratePresentOnGrnd();
        }
    }

    //�� ���� ���� �ڽ��� �����ϴ� �Լ�
    void GeneratePresentOnGrnd()
    {
        //���� ������Ʈ ����
        GameObject obj = Instantiate(presentOnGrnd);

        //��ġ - �ϴÿ��� ������ present2�� ���� �浹�� ����
        //       present2�� ��ü
        Vector3 present2Pos;
        present2Pos = this.gameObject.transform.position;

        obj.transform.position = present2Pos;
    }

}
