using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2에 등장하는 Enemy 산타를 생성하는 스크립트
public class GnrtEnemy : MonoBehaviour
{
    //Enemy Santa 프리팹 저장
    public GameObject enemy;

    //반복문 조건 변수
    bool onGoing;

    void Start()
    {
        //생성하기
        StartGnrt(); 
    }

    //생성을 시작하는 함수
    public void StartGnrt()
    {
        //생성 조건 변수 true로 설정
        onGoing = true;
        //1~3초 간격으로 랜덤 생성하기 - 코루틴 함수 호출
        StartCoroutine(GenerateEnemy());
    }

    //생성을 중단하는 함수
    public void StopGnrt()
    {
        //생성 조건 변수 false로 설정
        onGoing = false;
        //코루틴 함수 중단하기
        StopCoroutine(GenerateEnemy());
    }

    //Enemy 생성하는 함수
    IEnumerator GenerateEnemy()
    {
        //onGoing이 true인 동안 반복문 실행
        while(onGoing)
        {
            //10초 뒤에 다시 생성(대기)
            yield return new WaitForSeconds(10f);

            //생성
            GameObject obj = Instantiate(enemy);

            //생성 위치
            //Enemy가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.3f, 0.3f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.3f, 0.3f);

            //Enemy 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            
        }
        
    }
}
