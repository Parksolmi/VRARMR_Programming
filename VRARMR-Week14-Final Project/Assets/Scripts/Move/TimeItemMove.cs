using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage 2 에서의 시간 아이템을 움직이는 클래스
public class TimeItemMove : MonoBehaviour
{
    //아이템 오브젝트 움직이는(떨어지는) 속도
    public float speed;
    //아이템 오브젝트 움직이는 방향
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
