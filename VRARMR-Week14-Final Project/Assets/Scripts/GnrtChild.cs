using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtChild : MonoBehaviour
{
    //Child ������ ���� ���� ������Ʈ ����
    public GameObject child;

    public float gnrtTime;

    //���� �� ��� ��
    public int childNum;

    void Start()
    {
        //Child 15�� ���� �� �� ����
        StartCoroutine("GenerateEnemy");
    }

    IEnumerator GenerateEnemy()
    {
        while(childNum > 0)
        {
            //gnrtTime�� �ڿ� ����
            yield return new WaitForSeconds(gnrtTime);

            //����
            GameObject obj = Instantiate(child);

            //���� ��ġ
            //Child�� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Child�� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;

            childNum--;
        }
    }

}
