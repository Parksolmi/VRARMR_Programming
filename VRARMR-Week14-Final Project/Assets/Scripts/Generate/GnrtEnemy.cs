using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2�� �����ϴ� Enemy ��Ÿ�� �����ϴ� ��ũ��Ʈ
public class GnrtEnemy : MonoBehaviour
{
    //Enemy Santa ������ ����
    public GameObject enemy;

    //�ݺ��� ���� ����
    bool onGoing;

    void Start()
    {
        //�����ϱ�
        StartGnrt(); 
    }

    //������ �����ϴ� �Լ�
    public void StartGnrt()
    {
        //���� ���� ���� true�� ����
        onGoing = true;
        //1~3�� �������� ���� �����ϱ� - �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(GenerateEnemy());
    }

    //������ �ߴ��ϴ� �Լ�
    public void StopGnrt()
    {
        //���� ���� ���� false�� ����
        onGoing = false;
        //�ڷ�ƾ �Լ� �ߴ��ϱ�
        StopCoroutine(GenerateEnemy());
    }

    //Enemy �����ϴ� �Լ�
    IEnumerator GenerateEnemy()
    {
        //onGoing�� true�� ���� �ݺ��� ����
        while(onGoing)
        {
            //10�� �ڿ� �ٽ� ����(���)
            yield return new WaitForSeconds(10f);

            //����
            GameObject obj = Instantiate(enemy);

            //���� ��ġ
            //Enemy�� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.3f, 0.3f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.3f, 0.3f);

            //Enemy ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;

            
        }
        
    }
}
