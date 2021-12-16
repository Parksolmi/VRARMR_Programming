using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3�� �����ϴ� Child ������Ʈ�� �����ϴ� Ŭ����
public class GnrtChild : MonoBehaviour
{
    //Child ������ ���� ���� ������Ʈ ����
    public GameObject child;

    //Child ������ ���� �� ����Ʈ
    List<GameObject> childList = new List<GameObject>();

    //���� �ð�
    public float gnrtTime;

    //���� �� ��ü Child ��
    public int childNum;

    //���� �� child ��
    int gnrtNum;

    //getter & setter
    public int GetChildNum()
    {
        return childNum;
    }

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
        gnrtNum = 0; //gnrtNum�� 0���� �ʱ�ȭ
        int index = 0;

        while (gnrtNum != childNum) //gnrtNum�� childNum�� ������ ������
        {
            //gnrtTime�� �ڿ� ���� (���)
            yield return new WaitForSeconds(gnrtTime);

            //Child ����
            GameObject obj = Instantiate(child);
            //����Ʈ�� �߰�
            childList.Insert(index++, obj);

            //���� ��ġ
            //Child�� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Child�� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;

            //������ child�� ������Ű��
            gnrtNum++;
        }
    }

    //����Ʈ�� ����� ������Ʈ ��� ����� �Լ�
    public void DeleteList()
    {
        for(int i=0; i< gnrtNum; i++)
        {
            Destroy(childList[i]);
        }
    }
}