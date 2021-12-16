using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMove : MonoBehaviour
{
    public float speed;
    Vector3 moveDir;

    //스테이지 오브젝트
    private GameObject stage;

    void Start()
    {
        //스테이지 설정
        stage = GameObject.FindGameObjectWithTag("Stage3");

        //랜덤 방향으로 움직이기
        GameObject player = GameObject.FindGameObjectWithTag("Santa3");

        moveDir = player.transform.position - transform.position;
        moveDir.y = 0;

        float angle = Vector3.SignedAngle(
            transform.forward, moveDir.normalized, Vector3.up);

        //3초마다 방향 바꾸기
        StartCoroutine(ChangeDirection());

    }

    void Update()
    {
        //움직이기
        Vector3 deltaPos = transform.forward * speed * Time.deltaTime;
        transform.Translate(deltaPos, Space.World);
    }

    //3초마다 방향 바꾸기
    IEnumerator ChangeDirection()
    {
        while (true)
        {
            float angle = Random.Range(0, 360);
            transform.Rotate(0, angle, 0);

            yield return new WaitForSeconds(4.0f);
        }
    }
}
