using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����(����/��������) �����ϴ� �Լ�
public class GnrtBox : MonoBehaviour
{
    //���� ������Ʈ
    public GameObject present; //��������
    public GameObject woodBox; //��������

    //���� ���� ������ Ȯ��
    float rate = 0.5f;

    void Start()
    {
        //3�� �Ŀ� 1~3�� �������� ���� �����ϱ�
        InvokeRepeating("GenerateBox", 3, Random.Range(1, 3));
    }

    void Update()
    {
        
    }

    //�ڽ� ���� �Լ�
    void GenerateBox()
    {
        //���� ���ڰ� ������ ��� - Ȯ�� : 60%
        if(Random.Range(0.0f, 1.0f) < rate)
        {
            //�������� ����
            GameObject obj = Instantiate(present);

            //���� ���ڰ� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.4f; //�ϴÿ��� �����Ǿ�� �ϹǷ� ���� ���� ����
            randPos.z = Random.Range(-0.1f, 0.1f);

            //���� ���� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;
            
            //���� ���� �����̱�
            obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position, 
                                                            Vector3.down);
            
        }
        //���� ���ڰ� ������ ��� - Ȯ�� : 40%
        else //wood box
        {
            //���� ���� ����
            GameObject obj = Instantiate(woodBox);

            //���� ���ڰ� �����Ǵ� ���� ��ġ ����
            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.4f; //�ϴÿ��� �����Ǿ�� �ϹǷ� ���� ���� ����
            randPos.z = Random.Range(-0.1f, 0.1f);

            //���� ���� ��ġ = �÷��̾� ��ġ���� ���� ��ġ�� ���� ��
            obj.transform.position = transform.position + randPos;

            //���� ���� �����̱�
            obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position,
                                                            Vector3.down);

        }
        
    }
}
