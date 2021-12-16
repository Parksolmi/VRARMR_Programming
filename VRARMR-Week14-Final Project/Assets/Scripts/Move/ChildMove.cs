using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMove : MonoBehaviour
{
    public float speed;
    Vector3 moveDir;

    //�������� ������Ʈ
    private GameObject stage;

    void Start()
    {
        //�������� ����
        stage = GameObject.FindGameObjectWithTag("Stage3");

        //���� �������� �����̱�
        GameObject player = GameObject.FindGameObjectWithTag("Santa3");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);

        //3�ʸ��� ���� �ٲٱ�
        StartCoroutine(ChangeDirection());

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
        while (true)
        {
            float angle = Random.Range(0, 360);
            transform.Rotate(0, angle, 0);

            yield return new WaitForSeconds(4.0f);
        }
    }
}
