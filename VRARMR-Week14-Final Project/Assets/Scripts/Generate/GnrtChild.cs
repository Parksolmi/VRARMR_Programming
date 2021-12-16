using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3�� �����ϴ� Child ������Ʈ�� �����ϴ� Ŭ����
public class GnrtChild : MonoBehaviour
{
    //Child ������ ���� ���� ������Ʈ ����
    public GameObject child;

    public float gnrtTime;

    //���� �� ��ü Child ��
    public int childNum;

    //���� �ؾ� �� ��� ��(���� Child ��)
    int gnrtNum;

    void Start()
    {
        //Child�� 15�� ���� �� �� ����
        StartCoroutine("GenerateChild");
    }

    //�ڷ�ƾ �Լ��� �����ϴ� �Լ�
    public void StopGnrt()
    {
        StopCoroutine("GenerateChild");
    }

    //Child�� �����ϴ� �Լ�
    IEnumerator GenerateChild()
    {
        gnrtNum = childNum; //gnrtNum�� �ʱ� ������ ���� �ʱ�ȭ

        while (gnrtNum > 0) //gnrtNum�� 0�̻��� ���� �ݺ��� ����
        {
            //gnrtTime�� �ڿ� ���� (���)
            yield return new WaitForSeconds(gnrtTime);

            //Child ����
            GameObject obj = Instantiate(child);

            //���� ��ġ
            //Child�� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Child�� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;

            //������ �����ؾ� �� child�� ���ҽ�Ű��
            gnrtNum--;
        }
    }

}