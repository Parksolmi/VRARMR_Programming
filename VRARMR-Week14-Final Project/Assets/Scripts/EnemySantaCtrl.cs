using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySantaCtrl : MonoBehaviour
{
    public float speed;
    Vector3 moveDir;

    //Present2OnGrnd ������Ʈ�� �����ϴ� ����
    private GameObject present2OnGrnd;

    //Present2 ������Ʈ�� �����ϴ� ����
    public GameObject present2;

    //�������� ������Ʈ
    private GameObject stage;

    void Start()
    {
        present2OnGrnd = GameObject.FindWithTag("Present2OnGrnd");

        //�������� ����
        stage = GameObject.FindGameObjectWithTag("Stage2");

        if (present2OnGrnd != null)
        { 
            //���� ������ ���� ��ȯ
            GameObject present2OnGrnd = GameObject.FindGameObjectWithTag("Present2OnGrnd");

            moveDir = present2OnGrnd.transform.position - transform.position;
            moveDir.y = 0;

            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            transform.Rotate(0, angle, 0);
        }
        else
        {
            //���� �������� �����̱�
            GameObject player = GameObject.FindGameObjectWithTag("Santa2");

            moveDir = player.transform.position - transform.position;
            moveDir.y = 0;

            float angle = Vector3.SignedAngle(
                transform.forward, moveDir.normalized, Vector3.up);

            //3�ʸ��� ���� �ٲٱ�
            StartCoroutine(ChangeDirection());
        }
    }

    void Update()
    {
        //�����̱�
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //3�ʸ��� ���� �ٲٱ�
    IEnumerator ChangeDirection()
    {
        while(true)
        {
            float angle = Random.Range(0, 360);
            transform.Rotate(0, angle, 0);

            yield return new WaitForSeconds(4.0f);
        }
    }

    //�浹 �˻�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject); //�Ѿ� ����
            Destroy(this.gameObject); //enemy ����
        }
        if (other.tag == "Santa2")
        {
            //Ÿ�̸� ���̱� - 3��
            stage.GetComponent<Mng_Score>().MinusCountDown(3);
        }
        if (other.tag == "Present2OnGrnd")
        {
            stage.GetComponent<Mng_Score>().SubScore(1);
            //���� ����
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
