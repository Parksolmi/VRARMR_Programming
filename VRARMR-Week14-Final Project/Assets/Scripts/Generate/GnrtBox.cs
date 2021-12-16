using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����(����/��������) �����ϴ� Ŭ����
public class GnrtBox : MonoBehaviour
{
    //���� ������Ʈ
    public GameObject present; //��������
    public GameObject woodBox; //��������

    //���� ���� ������ Ȯ��
    public float rate;

    //���� ���� �ð� ����(range1 ~ range2)
    public int range1;
    public int range2;

    //�ݺ����� ���� �� ���Ǻ���
    bool onGoing;

    void Start()
    {
        //���� ���� ����
        StartGnrt();
    }

    void Update()
    {
        
    }

    //������ �����ϴ� �Լ�
    public void StartGnrt()
    {
        //�ݺ��� ���� true�� ����
        onGoing = true;
        //1~3�� �������� ���� �����ϱ� - �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(GenerateBox());
    }

    //������ �ߴ��ϴ� �Լ�
    public void StopGnrt()
    {
        //�ݺ��� ���� false�� ����
        onGoing = false;
        //�ڷ�ƾ �Լ� �����ϱ�
        StopCoroutine(GenerateBox());
    }
    
    //�ڽ� ���� �Լ�
    IEnumerator GenerateBox()
    {
        while(onGoing) //onGoing�� true�� ����
        {
            //���� ���ڰ� ������ ���
            if (Random.Range(0.0f, 1.0f) < rate)
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

                //�ƹ����� �浹���� �ʰ� ��� �������� ���
                Destroy(obj, 40);

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

                //�ƹ����� �浹���� �ʰ� ��� �������� ���
                Destroy(obj, 40);
            }

            //range1 ~ range2�� ���� ���
            yield return new WaitForSeconds(Random.Range(range1, range2));
        }
    }
}
