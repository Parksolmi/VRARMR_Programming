using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCylinder : MonoBehaviour
{
    public GameObject Cylinder;
   
    GameObject marker1;

    void Start()
    {
        marker1 = GameObject.FindGameObjectWithTag("marker1");
        //5�� �� 3�ʸ��� ����
        InvokeRepeating("CylinerSpawn", 5, 3);
    }

    //Cylinder���� ����
    void CylinerSpawn()
    {
        GameObject obj = Instantiate(Cylinder);

        //maker1�� ��ġ���� ����
        Vector3 marker1Pos;
        marker1Pos = marker1.transform.position;
        marker1Pos.y += 0.08f;

        obj.transform.position = marker1Pos;

        Destroy(obj, 10);
    }

}
