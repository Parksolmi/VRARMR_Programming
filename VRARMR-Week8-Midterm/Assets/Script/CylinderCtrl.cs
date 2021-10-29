using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderCtrl : MonoBehaviour
{
    public Material die;
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        //플레이어 쪽으로 방향 전환
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);

        transform.Rotate(0, angle, 0);

    }


    void Update()
    {
        Vector3 deltaPos = moveDir.normalized * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            if (enabled == true)
            {
                ScoreManager.instance.AddScore(1);
                Destroy(other.gameObject); //총알삭제
                GetComponent<Renderer>().material = die;
                Destroy(this.gameObject, 1); //cylinder삭제
                enabled = false;
            }
        }
    }

}
