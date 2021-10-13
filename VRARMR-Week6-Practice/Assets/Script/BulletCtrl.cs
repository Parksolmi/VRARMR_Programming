using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed;
    Vector3 direction;

    void Update()
    {
        Vector3 deltaPos = direction * speed * Time.deltaTime;
        transform.Translate(deltaPos);
    }

    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos;
        direction = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            Destroy(other.gameObject);
        }
    }
}
