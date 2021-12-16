using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������2�� �÷��̾� ĳ���� ��Ʈ�� Ŭ����
public class Santa2Ctrl : MonoBehaviour
{
    //�������� ����
    GameObject stage;

    //�� ������Ʈ ����
    public GameObject gun;

    //�Ѿ� ������Ʈ ����
    public GameObject bullet;

    //�÷��̾� ��ġ ����
    public Space mySpace;

    //������ġ�� ������ ����
    Vector3 prePos;

    //ȿ����
    public AudioClip shot; //����� Ŭ��
    AudioSource ads; //����� ������Ʈ�� ������ ����

    private void Start()
    {
        ads = GetComponent<AudioSource>(); //����� ������Ʈ ��������

        stage = GameObject.FindGameObjectWithTag("Stage2"); //�������� ���� ����
    }

    void Update()
    {
        //���콺 ���� ��ư�� ������ ĳ���� �̵� - Sanata1Ctrl Ŭ������ �ߺ�
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 0.1f);

            transform.Translate(deltaPos.x, 0, deltaPos.y, mySpace);
        }

        //���콺 ��ġ�� ���� ĳ���� ȸ�� - Sanata1Ctrl Ŭ������ �ߺ�
        Vector2 deltaPosForRotate = Input.mousePosition - prePos;
        deltaPosForRotate *= (Time.deltaTime * 10);
        transform.Rotate(0, deltaPosForRotate.x * 2, 0, Space.World);

        prePos = Input.mousePosition;

        //���콺 ������ ��ư ������ �Ѿ� �߻�
        if(Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward); //�߻� �Լ� ȣ��
        }
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
            //�����ڽ��� �浹 �� ���
            if (other.tag == "Present2")
            {
                stage.GetComponent<Mng_Score>().AddScore(1);//���� 1�� ȹ��
                Destroy(other.gameObject); //�ڽ� ������Ʈ ����
            }
            //���̹ڽ�
            if (other.tag == "WoodBox")
            {
                stage.GetComponent<Mng_Score>().SubScore(3); //���� 3�� ����
                Destroy(other.gameObject); //�ڽ� ������Ʈ ����
            }
        }
    }

    //�Ѿ� ���� �� �߻��ϴ� �Լ�
    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bullet); //�Ѿ� ����
        Vector3 shotPos = gun.transform.position; //�ѱ� ��ġ�� �߻� ��ġ�� ����

        //�Ѿ� ��� ȿ���� �߻�
        ads.PlayOneShot(shot);

        //�Ѿ� �����̱�
        obj.GetComponent<MoveBullet>().SetPosDir(shotPos, dir);

        //10�� �ڿ� �Ѿ� ���ֱ�
        Destroy(obj, 10);
    }
}
