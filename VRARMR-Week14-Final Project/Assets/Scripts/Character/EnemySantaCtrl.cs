using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2���� �����Ǵ� EnemySanta ��Ʈ�� ��ũ��Ʈ
public class EnemySantaCtrl : MonoBehaviour
{
    //EnemySanta �����̴� �ӵ�
    public float speed;
    //EnemySanta �����̴� ����
    Vector3 moveDir;

    //Present2OnGrnd ������Ʈ
    private GameObject present2OnGrnd;

    //Present2 ������Ʈ
    public GameObject present2;

    //�������� ������Ʈ
    private GameObject stage;

    void Start()
    {
        //�������� ���� ����
        stage = GameObject.FindGameObjectWithTag("Stage2");

        //present2OnGrnd ���� ����
        present2OnGrnd = GameObject.FindWithTag("Present2OnGrnd");

        //present2OnGrnd�� �����Ǿ� �ִٸ�(��, �ٴڿ� ������ ���� ���ڰ� �ִٸ�)
        if (present2OnGrnd != null)
        { 
            //���� ������ ���� ��ȯ
            GameObject present2OnGrnd = GameObject.FindGameObjectWithTag("Present2OnGrnd");

            //���� �� ���� ���ϱ�
            moveDir = present2OnGrnd.transform.position - transform.position;
            moveDir.y = 0;

            //������Ʈ ȸ�� ���� ���ϱ�
            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            //������ ���� ��ŭ ȸ���Ͽ� EnemySanta�� ������ ���ϵ��� ��
            transform.Rotate(0, angle, 0);
        }
        else //�ٴڿ� ������ �ִ� ���� ���ڰ� ���ٸ� �����ϰ� �����δ�
        {
            //�÷��̾� ������ ���� ��ȯ
            GameObject player = GameObject.FindGameObjectWithTag("Santa2");

            //�÷��̾� �� ���� ���ϱ�
            moveDir = player.transform.position - transform.position;
            moveDir.y = 0;

            //������Ʈ ȸ�� ���� ���ϱ�
            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            //4�ʸ��� �����ϰ� ���� �ٲٱ�
            StartCoroutine(ChangeDirection());
        }
    }

    void Update()
    {
        //������ �������� �����Ͽ� �����̱�
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //3�ʸ��� ���� �ٲٱ�
    IEnumerator ChangeDirection()
    {
        while(true)
        {
            //���� ������ angle������ ����
            float angle = Random.Range(0, 360);
            //angle���� ��ŭ ������Ʈ ȸ�� ��Ű��(����ٲٱ�)
            transform.Rotate(0, angle, 0);

            //4�� ��� - ����ϴ� ���� ������Ʈ�� ������ �������� ����
            yield return new WaitForSeconds(4.0f);
        }
    }

    //�浹 �˻�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")//�Ѿ��̶� �浹 ���� ��
        {
            Destroy(other.gameObject); //�Ѿ� ����
            Destroy(this.gameObject); //enemy ����
        }
        if (other.tag == "Santa2")//�÷��̾�� �浹 ���� ��
        {
            //Ÿ�̸� ���̱� - 3��
            stage.GetComponent<Mng_Score>().MinusCountDown(3);
        }
        if (other.tag == "Present2OnGrnd") //���� ������ ������ �浹 ���� ��
        {
            //���� 1�� ����
            stage.GetComponent<Mng_Score>().SubScore(1);
            Destroy(other.gameObject); //���� ����
            Destroy(this.gameObject); //�ڱ��ڽ�(EnemySanta)����
        }
    }
}
