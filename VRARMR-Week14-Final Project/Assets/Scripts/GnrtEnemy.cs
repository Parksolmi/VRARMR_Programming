using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtEnemy : MonoBehaviour
{
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        //�÷��̾� ������ ���� ��ȯ
        GameObject player = GameObject.FindGameObjectWithTag("Santa2");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);

        transform.Rotate(0, angle, 0);

    }

    void Update()
    {
        Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //�浹 �˻�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            
        }
        if (other.tag == "Santa2")
        {

        }
        if (other.tag == "Present2")
        {

        }
    }
}
