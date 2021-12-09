using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������1�� �÷��̾� ĳ���Ϳ� ���� Ŭ����
public class Santa1Ctrl : MonoBehaviour
{
    //�÷��̾ ������ ���� ������Ʈ ����
    public GameObject player;

    //�÷��̾� ��ġ ����
    public Space mySpace;

    //������ġ�� ������ ����
    Vector3 prePos; 

    void Update()
    {
        //���콺 ���� ��ư�� ������ ĳ���� �̵�
        if(Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //prePos�� ���콺 ��ġ�� �ִ´�
        prePos = Input.mousePosition;

        //���콺 ��ġ�� ���� ĳ���� ȸ��

    }

    //�ش� ���� ������Ʈ�� ��Ȱ��ȭ ��Ű�� �Լ�
    public void setActiveFalse()
    {
        player.SetActive(false);
    }
    //�ش� ���� ������Ʈ�� Ȱ��ȭ ��Ű�� �Լ�
    public void setActiveTrue()
    {
        player.SetActive(true);
    }

}
