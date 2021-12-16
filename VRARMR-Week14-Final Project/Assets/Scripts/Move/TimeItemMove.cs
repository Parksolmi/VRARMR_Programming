using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage 2 ������ �ð� �������� �����̴� Ŭ����
public class TimeItemMove : MonoBehaviour
{
    //������ ������Ʈ �����̴�(��������) �ӵ�
    public float speed;
    //������ ������Ʈ �����̴� ����
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
