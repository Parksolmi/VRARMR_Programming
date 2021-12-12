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
    public float rate;

    //���� ���� �ð� ����
    public int range1;
    public int range2;

    void Start()
    {
        InvokeGnrt();
    }

    void Update()
    {
        
    }

    public void InvokeGnrt()
    {
        //3�� �Ŀ� 1~3�� �������� ���� �����ϱ�
        InvokeRepeating("GenerateBox", 3, Random.Range(range1, range2));
    }

    //�ڽ� ���� �Լ�
    void GenerateBox()
    {
        //���� ���ڰ� ������ ���
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
        //���� ���ڰ� ������ ���
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
