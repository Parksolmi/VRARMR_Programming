using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//움직이는 방향 : 랜덤
public class CapsuleCtrl : MonoBehaviour
{
    public Material die;
    public float speed;
    Vector3 moveDir;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);

        //2초마다 방향 바꾸기
        InvokeRepeating("ChangeDirection", 1, 2);
    }

    void Update()
    {
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //2초마다 방향 바꾸기
    void ChangeDirection()
    {
        float angle = Random.Range(0, 360);
        transform.Rotate(0, angle, 0);
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
                Destroy(this.gameObject, 1); //capsule삭제
                enabled = false;
            }
        }
    }
}
