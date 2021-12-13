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

    bool onGoing;

    void Start()
    {
        StartGnrt();
    }

    void Update()
    {
        
    }

    public void StartGnrt()
    {
        onGoing = true;
        //1~3�� �������� ���� �����ϱ�
        StartCoroutine(GenerateBox());
    }

    public void StopGnrt()
    {
        onGoing = false;
        StopCoroutine(GenerateBox());
    }
    
    //�ڽ� ���� �Լ�
    IEnumerator GenerateBox()
    {
        while(onGoing)
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

            yield return new WaitForSeconds(Random.Range(range1, range2));
        }
        
        
    }
}
