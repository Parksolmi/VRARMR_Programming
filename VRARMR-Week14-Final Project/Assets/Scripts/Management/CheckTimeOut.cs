using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2에서 선물 상자가 time-out되어 없어졌는지
//도둑 산타(Enemy Santa)가 훔쳐가서 없어졌는지 검사하는 클래스
public class CheckTimeOut : MonoBehaviour
{
    //스테이지 저장 할 게임 오브젝트
    GameObject stage;

    //타임아웃 여부를 저장하는 변수
    bool isTimeOut;

    //getter
    public bool GetIsTimeOut()
    {
        return isTimeOut;
    }

    void Start()
    {
        //스테이지 변수 설정
        stage = GameObject.FindGameObjectWithTag("Stage2");

        //타임아웃 true로 설정
        isTimeOut = true;

        //코루틴 함수 호출 - destroy 후에 isTimeOut여부를 검사하기 위해서
        StartCoroutine(PlusScore());
    }

    //충돌 검사
    private void OnTriggerEnter(Collider other)
    {
        //Enemy Santa와 충돌 한 경우 타임 아웃으로 사라진 것이 아니므로
        //isTimeOut변수 false로 설정
        if (other.tag == "EnemySanta")
        {
            isTimeOut = false;
        }
    }

    //점수 획득 함수
    IEnumerator PlusScore()
    {
        //15초 후에 검사
        yield return new WaitForSeconds(15f);

        //타임아웃이 맞다면
        if (isTimeOut)
        {
            //선물을 지켰으므로 1점 획득
            stage.GetComponent<Mng_Score>().AddScore(1);
        }

        //오브젝트 삭제
        Destroy(this.gameObject);
    }
}
