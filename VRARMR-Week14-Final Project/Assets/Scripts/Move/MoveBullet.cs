using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총알을 움직이는 클래스
public class MoveBullet : MonoBehaviour
{
    public float speed; //움직이는 속도
    Vector3 direction; //움직이는 방향

    void Update()
    {
        //움직이는 위치 설정
        Vector3 deltaPos = direction * speed * Time.deltaTime;
        //해당 위치로 이동
        transform.Translate(deltaPos);
    }

    //총알 위치,방향을 설정하는 함수
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        transform.position = pos; //위치 설정
        direction = dir; //방향 설정
    }

}