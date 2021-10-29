using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCapsule : MonoBehaviour
{
    public GameObject Capsule;

    GameObject marker2;

    void Start()
    {
        marker2 = GameObject.FindGameObjectWithTag("marker2");
        //5�� �� 3�ʸ��� ����
        InvokeRepeating("CapsuleSpawn", 5, 4);
    }

    //Capsule���� ����
    void CapsuleSpawn()
    {
        GameObject obj = Instantiate(Capsule);

        //maker2�� ��ġ���� ����
        Vector3 marker2Pos;
        marker2Pos = marker2.transform.position;
        marker2Pos.y += 0.08f;

        float randDeg = Random.Range(0, 360);

        obj.transform.position = marker2Pos;
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);

        Destroy(obj, 10);
    }
}
