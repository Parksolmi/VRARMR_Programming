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

        //���콺 ��ġ�� ���� ĳ���� ȸ��
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        prePos = Input.mousePosition;
    }

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        int score = Mng_Score.instance.GetScore();
        int goal = Mng_Score.instance.GetGoal();

        if(score < goal && score >= 0)
        {
            //�����ڽ�
            if (other.tag == "Present")
            {
                Mng_Score.instance.AddScore(1);
                Destroy(other.gameObject);
            }
            //���̹ڽ�
            if (other.tag == "WoodBox")
            {
                Mng_Score.instance.SubScore(3);
                Destroy(other.gameObject);
            }
        }
        
    }

}
