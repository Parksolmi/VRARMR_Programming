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
        //5초 후 3초마다 생성
        InvokeRepeating("CylinerSpawn", 5, 3);
    }

    //Cylinder몬스터 생성
    void CylinerSpawn()
    {
        GameObject obj = Instantiate(Cylinder);

        //maker1의 위치에서 생성
        Vector3 marker1Pos;
        marker1Pos = marker1.transform.position;
        marker1Pos.y += 0.08f;

        obj.transform.position = marker1Pos;

        Destroy(obj, 10);
    }

}
