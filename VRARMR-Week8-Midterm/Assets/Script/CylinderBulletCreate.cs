using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBulletCreate : MonoBehaviour
{
    public GameObject CylinderBullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CylinderShot", 4, 1);
    }

    void CylinderShot()
    {
        GameObject obj = Instantiate(CylinderBullet);

        Vector3 objPos;
        objPos = transform.position;

        float randDeg = Random.Range(0, 360);

        obj.transform.position = objPos;
        obj.transform.rotation = Quaternion.Euler(0, randDeg, 0);

        Destroy(obj, 5);
    }
}
