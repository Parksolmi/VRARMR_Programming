using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtPortal : MonoBehaviour
{
    //���� ������Ʈ
    public GameObject portal1; //��� ����
    public GameObject portal2; //�������� ����

    //��� ������ ������ Ȯ��
    public float rate;

    //���� ���� �ð� ����
    public int gnrtTime;

    bool onGoing;

    void Start()
    {
        //2�� �ڿ� ���� �Լ� ȣ�� ����
        Invoke("StartGnrt", 2);
    }

    public void StartGnrt()
    {
        onGoing = true;
        StartCoroutine(GeneratePortal());
    }

    public void StopGnrt()
    {
        onGoing = false;
        StopCoroutine(GeneratePortal());
    }

    IEnumerator GeneratePortal()
    {
        while(onGoing)
        {
            if(Random.Range(0.0f, 1.0f) < rate)
            {
                //Portal1����
                GameObject obj = Instantiate(portal1);

                //���� �Ǵ� ���� ��ġ
                Vector3 randPos;
                randPos.x = Random.Range(-0.2f, 0.2f);
                randPos.y = 0.02f;
                randPos.z = Random.Range(-0.2f, 0.2f);

                //���� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
                obj.transform.position = transform.position + randPos;

                //4�� �ڿ� ���ֱ�
                Destroy(obj, 4);
            }
            else
            {
                //Portal2����
                GameObject obj = Instantiate(portal2);

                //���� �Ǵ� ���� ��ġ
                Vector3 randPos;
                randPos.x = Random.Range(-0.2f, 0.2f);
                randPos.y = 0.02f;
                randPos.z = Random.Range(-0.2f, 0.2f);

                //���� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
                obj.transform.position = transform.position + randPos;

                //4�� �ڿ� ���ֱ�
                Destroy(obj, 4);
            }
            //gnrtTime�� �������� ���� �����ϱ�
            yield return new WaitForSeconds(gnrtTime);
        }
        
    }
}
