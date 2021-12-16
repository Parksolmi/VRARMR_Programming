using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3에 등장하는 Child 오브젝트를 생성하는 클래스
public class GnrtChild : MonoBehaviour
{
    //Child 프리팹 넣을 게임 오브젝트 변수
    public GameObject child;

    public float gnrtTime;

    //생성 할 전체 Child 수
    public int childNum;

    //생성 해야 할 어린이 수(남은 Child 수)
    int gnrtNum;

    void Start()
    {
        //Child를 15초 마다 한 명씩 생성
        StartCoroutine("GenerateChild");
    }

    //코루틴 함수를 종료하는 함수
    public void StopGnrt()
    {
        StopCoroutine("GenerateChild");
    }

    //Child를 생성하는 함수
    IEnumerator GenerateChild()
    {
        gnrtNum = childNum; //gnrtNum을 초기 설정한 수로 초기화

        while (gnrtNum > 0) //gnrtNum이 0이상인 동안 반복문 실행
        {
            //gnrtTime초 뒤에 생성 (대기)
            yield return new WaitForSeconds(gnrtTime);

            //Child 생성
            GameObject obj = Instantiate(child);

            //생성 위치
            //Child가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Child가 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            //앞으로 생성해야 할 child수 감소시키기
            gnrtNum--;
        }
    }

}