using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������1�� �÷��̾� ĳ���Ϳ� ���� Ŭ����
public class Santa1Ctrl : MonoBehaviour
{
    //�������� ������Ʈ �����ϴ� ����
    GameObject stage;

    //�÷��̾ ������ ���� ������Ʈ ����
    public GameObject player;

    //�÷��̾� ��ġ ����
    public Space mySpace;

    //������ġ�� ������ ����
    Vector3 prePos;

    private void Start()
    {
        stage = GameObject.FindGameObjectWithTag("Stage1");
    }

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
        bool isSuccess = stage.GetComponent<Mng_Score>().GetIsSuccess();
        bool isFail = stage.GetComponent<Mng_Score>().GetIsFail();

        if (!isSuccess && !isFail)
        {
            //�����ڽ�
            if (other.tag == "Present")
            {
                stage.GetComponent<Mng_Score>().AddScore(1);
                Destroy(other.gameObject);
            }
            //���̹ڽ�
            if (other.tag == "WoodBox")
            {
                stage.GetComponent<Mng_Score>().SubScore(3);
                Destroy(other.gameObject);
            }
        }
        
    }

}
