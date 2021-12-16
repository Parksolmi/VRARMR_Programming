using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3에 등장하는 포털을 생성하는 클래스
public class GnrtPortal : MonoBehaviour
{
    //상자 오브젝트
    public GameObject portal1; //배달 포털
    public GameObject portal2; //쓰레기통 포털

    //배달 포털이 나오는 확률
    public float rate;

    //랜덤 생성 시간 범위
    public int gnrtTime;

    //생성 반복문 조건 변수
    bool onGoing;

    void Start()
    {
        //2초 뒤에 생성 함수 호출 시작
        Invoke("StartGnrt", 2);
    }

    //생성을 시작하는 함수
    public void StartGnrt()
    {
        //생성 조건 변수 true로 설정
        onGoing = true;
        //생성하기 - 코루틴 함수 호출
        StartCoroutine(GeneratePortal());
    }

    //생성을 중단하는 함수
    public void StopGnrt()
    {
        //생성 조건 변수 false로 설정
        onGoing = false;
        //코루틴 함수 중단
        StopCoroutine(GeneratePortal());
    }

    //포털을 생성하는 함수
    IEnumerator GeneratePortal()
    {
        while(onGoing)
        {
            if(Random.Range(0.0f, 1.0f) < rate)
            {
                //Portal1생성
                GameObject obj = Instantiate(portal1);

                //생성 되는 랜덤 위치
                Vector3 randPos;
                randPos.x = Random.Range(-0.2f, 0.2f);
                randPos.y = 0.02f;
                randPos.z = Random.Range(-0.2f, 0.2f);

                //포털 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
                obj.transform.position = transform.position + randPos;

                //4초 뒤에 없애기
                Destroy(obj, 4);
            }
            else
            {
                //Portal2생성
                GameObject obj = Instantiate(portal2);

                //생성 되는 랜덤 위치
                Vector3 randPos;
                randPos.x = Random.Range(-0.2f, 0.2f);
                randPos.y = 0.02f;
                randPos.z = Random.Range(-0.2f, 0.2f);

                //포털 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
                obj.transform.position = transform.position + randPos;

                //4초 뒤에 없애기
                Destroy(obj, 4);
            }
            //gnrtTime초 간격으로 랜덤 생성하기
            yield return new WaitForSeconds(gnrtTime);
        }
        
    }
}
