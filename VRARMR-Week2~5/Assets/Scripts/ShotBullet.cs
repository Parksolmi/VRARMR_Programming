using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject bulletObj;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Shot(transform.forward);//��
            Shot(-transform.forward);//��
            Shot(-transform.right);//��
            Shot(transform.right);//��
            Shot(transform.up);//��

        }
    }

    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletMove>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }
}
