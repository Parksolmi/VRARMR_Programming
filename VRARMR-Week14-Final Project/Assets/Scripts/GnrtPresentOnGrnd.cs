using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtPresentOnGrnd : MonoBehaviour
{
    //PresentOnGrnd ������ ���� �� ���ӿ�����Ʈ
    public GameObject presentOnGrnd;

    //�浹ó��
    private void OnCollisionEnter(Collision other)
    {
        //��
        if (other.gameObject.tag.Equals("Ground"))
        {
            //����
            GeneratePresentOnGrnd();
        }
    }

    //�� ���� �ڽ� ����
    void GeneratePresentOnGrnd()
    {
        GameObject obj = Instantiate(presentOnGrnd);

        //��ġ
        Vector3 present2Pos;
        present2Pos = this.gameObject.transform.position;

        obj.transform.position = present2Pos;

        //20�� �ڿ� ����
        Destroy(obj, 20);
    }
}
