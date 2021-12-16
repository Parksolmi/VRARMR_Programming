using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상자(선물/쓰레기통) 생성하는 클래스
public class GnrtBox : MonoBehaviour
{
    //상자 오브젝트
    public GameObject present; //선물상자
    public GameObject woodBox; //나무상자

    //선물 상자 나오는 확률
    public float rate;

    //랜덤 생성 시간 범위(range1 ~ range2)
    public int range1;
    public int range2;

    //반복문을 제어 할 조건변수
    bool onGoing;

    void Start()
    {
        //선물 생성 시작
        StartGnrt();
    }

    void Update()
    {
        
    }

    //생성을 시작하는 함수
    public void StartGnrt()
    {
        //반복문 조건 true로 설정
        onGoing = true;
        //1~3초 간격으로 랜덤 생성하기 - 코루틴 함수 호출
        StartCoroutine(GenerateBox());
    }

    //생성을 중단하는 함수
    public void StopGnrt()
    {
        //반복문 조건 false로 설정
        onGoing = false;
        //코루틴 함수 종료하기
        StopCoroutine(GenerateBox());
    }
    
    //박스 생성 함수
    IEnumerator GenerateBox()
    {
        while(onGoing) //onGoing이 true인 동안
        {
            //선물 상자가 나오는 경우
            if (Random.Range(0.0f, 1.0f) < rate)
            {
                //선물상자 생성
                GameObject obj = Instantiate(present);

                //선물 상자가 생성되는 랜덤 위치 설정
                Vector3 randPos;
                randPos.x = Random.Range(-0.1f, 0.1f);
                randPos.y = 0.4f; //하늘에서 생성되어야 하므로 높이 고정 설정
                randPos.z = Random.Range(-0.1f, 0.1f);

                //선물 상자 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
                obj.transform.position = transform.position + randPos;

                //선물 상자 움직이기
                obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position,
                                                                Vector3.down);

                //아무데도 충돌하지 않고 계속 떨어지는 경우
                Destroy(obj, 40);

            }
            //나무 상자가 나오는 경우
            else //wood box
            {
                //나무 상자 생성
                GameObject obj = Instantiate(woodBox);

                //나무 상자가 생성되는 랜덤 위치 설정
                Vector3 randPos;
                randPos.x = Random.Range(-0.1f, 0.1f);
                randPos.y = 0.4f; //하늘에서 생성되어야 하므로 높이 고정 설정
                randPos.z = Random.Range(-0.1f, 0.1f);

                //나무 상자 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
                obj.transform.position = transform.position + randPos;

                //나무 상자 움직이기
                obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position,
                                                                Vector3.down);

                //아무데도 충돌하지 않고 계속 떨어지는 경우
                Destroy(obj, 40);
            }

            //range1 ~ range2초 동안 대기
            yield return new WaitForSeconds(Random.Range(range1, range2));
        }
    }
}
