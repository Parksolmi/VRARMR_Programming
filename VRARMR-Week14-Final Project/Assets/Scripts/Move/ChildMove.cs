using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Child 오브젝트 움직이는 클래스
public class ChildMove : MonoBehaviour
{
    public float speed; //움직이는 속도
    Vector3 moveDir; //움직이는 방향

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

    //4초마다 방향 바꾸기
    IEnumerator ChangeDirection()
    {
        while (true)
        {
            //랜덤 각도 설정
            float angle = Random.Range(0, 360);
            transform.Rotate(0, angle, 0); //회전하기

            //4초 대기
            yield return new WaitForSeconds(4.0f);
        }
    }
}
