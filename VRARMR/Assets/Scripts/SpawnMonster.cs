using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monObj;

    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Invoke("Spawn", 0.5f);
        }
        else if(Input.GetKeyDown("2"))
        {
            InvokeRepeating("Spawn", 1.0f, 2.0f);
        }
        else if(Input.GetKeyDown("3"))
        {
            CancelInvoke("Spawn");
        }
        else if(Input.GetKeyDown("4"))
        {
            CancelInvoke();
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(monObj);

        Vector3 randPos;
        randPos.x = Random.Range(-0.2f, 0.2f);
        randPos.y = 0;
        randPos.z = Random.Range(-0.2f, 0.2f);

        float randDeg = Random.Range(0, 360);

        obj.transform.position = transform.position + randPos;
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);

        Destroy(obj, 10);
    }
}
