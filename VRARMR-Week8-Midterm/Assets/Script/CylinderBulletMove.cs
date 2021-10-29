using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBulletMove : MonoBehaviour
{
    public float speed;
    Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }
}
