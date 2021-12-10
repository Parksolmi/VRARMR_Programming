using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ڽ� ������Ʈ �Ʒ��� �����̵��� �ϴ� ��ũ��Ʈ
public class MoveBox : MonoBehaviour
{
    //�ڽ� ������Ʈ �����̴�(��������) �ӵ�
    public float speed;
    //�ڽ� ������Ʈ �����̴� ����
    Vector3 direction;

    void Update()
    {
        //���⿡ �ӵ��� deltaTime�� ���Ͽ� deltaPos�� ����
        Vector3 deltaPos = direction * speed * Time.deltaTime;
        //deltaPos��ġ�� �̵��ϴ� �Լ�
        transform.Translate(deltaPos);
    }

    //�����̴� ������ �����ϴ� �Լ�
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        //��ġ ����
        transform.position = pos;
        //���� ����
        direction = dir;
    }

    
}
