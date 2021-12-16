using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ѿ��� �����̴� Ŭ����
public class MoveBullet : MonoBehaviour
{
    public float speed; //�����̴� �ӵ�
    Vector3 direction; //�����̴� ����

    void Update()
    {
        //�����̴� ��ġ ����
        Vector3 deltaPos = direction * speed * Time.deltaTime;
        //�ش� ��ġ�� �̵�
        transform.Translate(deltaPos);
    }

    //�Ѿ� ��ġ,������ �����ϴ� �Լ�
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos; //��ġ ����
        direction = dir; //���� ����
    }

}