using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����̴� ���� : ����
public class CapsuleCtrl : MonoBehaviour
{
    public Material die;
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);

        //2�ʸ��� ���� �ٲٱ�
        InvokeRepeating("ChangeDirection", 1, 2);
    }

    void Update()
    {
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //2�ʸ��� ���� �ٲٱ�
    void ChangeDirection()
    {
        float angle = Random.Range(0, 360);
        transform.Rotate(0, angle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            if (enabled == true)
            {
                ScoreManager.instance.AddScore(1);
                Destroy(other.gameObject); //�Ѿ˻���
                GetComponent<Renderer>().material = die;
                Destroy(this.gameObject, 1); //capsule����
                enabled = false;
            }
        }
    }
}
