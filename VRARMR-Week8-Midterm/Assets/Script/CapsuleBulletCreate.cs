using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBulletCreate : MonoBehaviour
{
    public GameObject CapsuleBullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CapsuleShot", 4, 1);
    }

    void CapsuleShot()
    {
        GameObject obj = Instantiate(CapsuleBullet);

        Vector3 objPos;
        objPos = transform.position;

        obj.transform.position = objPos;

        Destroy(obj, 5);
    }
}
