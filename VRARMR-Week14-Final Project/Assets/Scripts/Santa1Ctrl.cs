using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa1Ctrl : MonoBehaviour
{
    public GameObject player;
    //�÷��̾� ��ġ ����
    public Space mySpace;
    
    Vector3 prePos; //������ġ�� ������ ����

    void Update()
    {
        //���콺 ���� ��ư�� ������ ĳ���� �̵�
        if(Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        prePos = Input.mousePosition;

        //���콺 ������ ��ư���� �Ѿ� �߻�
        if(Input.GetMouseButtonDown(1))
        {

        }
        //���콺 ��ġ�� ���� ĳ���� ȸ��

    }

    public void setActiveFalse()
    {
        player.SetActive(false);
    }

    public void setActiveTrue()
    {
        player.SetActive(true);
    }

}
