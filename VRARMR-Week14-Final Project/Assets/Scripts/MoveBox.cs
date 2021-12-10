using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//박스 오브젝트 아래로 움직이도록 하는 스크립트
public class MoveBox : MonoBehaviour
{
    //박스 오브젝트 움직이는(떨어지는) 속도
    public float speed;
    //박스 오브젝트 움직이는 방향
    Vector3 direction;

    void Update()
    {
        //방향에 속도와 deltaTime을 곱하여 deltaPos에 저장
        Vector3 deltaPos = direction * speed * Time.deltaTime;
        //deltaPos위치로 이동하는 함수
        transform.Translate(deltaPos);
    }

    //움직이는 방향을 설정하는 함수
    public void SetPosDir(Vector3 pos, Vector3 dir)
    {
        //위치 설정
        transform.position = pos;
        //방향 설정
        direction = dir;
    }

    
}
