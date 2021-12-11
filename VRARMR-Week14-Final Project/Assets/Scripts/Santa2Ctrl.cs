using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa2Ctrl : MonoBehaviour
{
    //�÷��̾ ������ ���� ������Ʈ ����
    public GameObject player;

    //�� ������ ���� ������Ʈ ����
    public GameObject gun;

    //�Ѿ� ������ ���� ������Ʈ ����
    public GameObject bullet;

    //�÷��̾� ��ġ ����
    public Space mySpace;

    //������ġ�� ������ ����
    Vector3 prePos;

    //���� �Ŵ��� ��ü�� ������ ����
    public GameObject gameMng;

    void Update()
    {
        //���콺 ���� ��ư�� ������ ĳ���� �̵�
        if (Input.GetMouseButton(0))
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

        //���콺 ������ ��ư ������ �Ѿ� �߻�
        if(Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward);
        }
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

    //�浹ó��
    private void OnTriggerEnter(Collider other)
    {
        int score = gameMng.GetComponent<GameMng>().GetScore();
        int goal = gameMng.GetComponent<GameMng>().GetGaol();

        if (score < goal && score >= 0)
        {
            //�����ڽ�
            if (other.tag == "Present2")
            {
                gameMng.GetComponent<GameMng>().SetIsCollisionP(true);
                Destroy(other.gameObject);
            }
            //���̹ڽ�
            if (other.tag == "WoodBox")
            {
                gameMng.GetComponent<GameMng>().SetIsCollisionB(true);
                Destroy(other.gameObject);
            }
        }

    }

    //�Ѿ� ���� �� �߻��ϴ� �Լ�
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bullet);
        Vector3 shotPos = gun.transform.position;

        obj.GetComponent<MoveBullet>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }
}
