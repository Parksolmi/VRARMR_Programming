using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������3�� �÷��̾� ĳ���� ��Ʈ�� Ŭ����
public class Santa3Ctrl : MonoBehaviour
{
    //�������� ������Ʈ �����ϴ� ����
    GameObject stage;

    //�÷��̾� ��ġ ����
    public Space mySpace;

    //������ġ�� ������ ����
    Vector3 prePos;

    
    private void Start()
    {
        //�������� ���� ����
        stage = GameObject.FindGameObjectWithTag("Stage3");
    }

    void Update()
    {
        //���콺 ���� ��ư�� ������ ĳ���� �̵� - Santa1Ctrl�� �ߺ�
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //���콺 ��ġ�� ���� ĳ���� ȸ�� - Santa1Ctrl�� �ߺ�
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        prePos = Input.mousePosition;

    }

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        //Score���� Ŭ�������� ���� ���ῡ ���� ���� ��������
        int score = stage.GetComponent<Mng_Score>().GetScore();
        int goal = stage.GetComponent<Mng_Score>().GetGoal();

        //������ ����Ǵ� ����(���� ����, ���а� �������� ���� ��Ȳ)
        if (score < goal && score >= 0)
        {
            if (other.tag == "Child") //Child�� �浹 �� ���
            {
                stage.GetComponent<Mng_Score>().SetCountDown(0); //���� ����
            }
        }
    }
}
