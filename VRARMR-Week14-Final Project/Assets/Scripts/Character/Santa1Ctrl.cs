using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������1�� �÷��̾� ĳ���� ��Ʈ�� Ŭ����
public class Santa1Ctrl : MonoBehaviour
{
    //�������� ����
    GameObject stage;

    //�÷��̾� ����
    public GameObject player;

    //�÷��̾� ��ġ ����
    public Space mySpace;

    //������ġ�� ������ ����
    Vector3 prePos;

    private void Start()
    {
        //�������� ���� ����
        stage = GameObject.FindGameObjectWithTag("Stage1");
    }

    void Update()
    {
        //���콺 ���� ��ư�� ������ ĳ���� �̵�
        if(Input.GetMouseButton(0))
        {
            //���콺 ��ġ���� ���� ��ġ�� �� ��ġ�� deltaPos������ ����
            Vector2 deltaPos = Input.mousePosition - prePos;
            //������ �ð����� �����̰� �ϱ� ���ؼ� deltaTime���ϱ�
            deltaPos *= (Time.deltaTime * 0.1f);

            //���콺 ��ġ�� ���� ��� ��ġ�� ������Ʈ �ű��
            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //���콺 ��ġ�� ���� ĳ���� ȸ��
        //���콺 ��ġ���� ���� ��ġ�� �� ��ġ�� deltaPosForRotate������ ����
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        //������ �ð����� �����̰� �ϱ� ���ؼ� deltaTime���ϱ�
        deltaPosForRotate *= (Time.deltaTime * 10);
        //������ ���� ��ŭ ������Ʈ ȸ���ϱ�
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        //���� ���콺 ��ġ�� ���� ��ġ ������ ����
        prePos = Input.mousePosition;
    }

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        //Score���� Ŭ�������� ���� ���ῡ ���� ���� ��������
        bool isSuccess = stage.GetComponent<Mng_Score>().GetIsSuccess();
        bool isFail = stage.GetComponent<Mng_Score>().GetIsFail();

        //������ ����Ǵ� ����(���� ����, ���а� �������� ���� ��Ȳ)
        if (!isSuccess && !isFail)
        {
            //�����ڽ��� �浹 �� ���
            if (other.tag == "Present")
            {
                stage.GetComponent<Mng_Score>().AddScore(1); //���� 1�� ȹ��
                Destroy(other.gameObject); //�ڽ� ������Ʈ ����
            }
            //���̹ڽ��� �浹�� ���
            if (other.tag == "WoodBox")
            {
                stage.GetComponent<Mng_Score>().SubScore(3); //���� 3�� ����
                Destroy(other.gameObject); //�ڽ� ������Ʈ ����
            }
        }
        
    }

}
