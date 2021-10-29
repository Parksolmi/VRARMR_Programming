using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public GameObject item;

    void Start()
    {
        InvokeRepeating("ItemCreate", 10, Random.Range(5f, 10f));
    }

    //아이템 생성
    void ItemCreate()
    {
        GameObject obj = Instantiate(item);

        Vector3 randPos;
        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;
        randPos.z = Random.Range(-0.2f, 0.2f);

        float randDeg = Random.Range(0, 360);

        obj.transform.position = transform.position + randPos;
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);

        Destroy(obj, 5);
    }

}

