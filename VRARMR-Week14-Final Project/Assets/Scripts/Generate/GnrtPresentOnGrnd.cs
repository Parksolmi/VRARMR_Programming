using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage2에 등장하는 땅에 떨어진 선물 상자를 생성하는 클래스
public class GnrtPresentOnGrnd : MonoBehaviour
{
    //PresentOnGrnd 프리팹 저장 할 게임오브젝트
    public GameObject presentOnGrnd;

    //충돌처리
    private void OnTriggerEnter(Collider other)
    {
        //땅과 충돌한 경우
        if (other.gameObject.tag.Equals("Ground"))
        {
            //선물 오브젝트를 생성하기
            GeneratePresentOnGrnd();
        }
    }

    //땅 위에 선물 박스를 생성하는 함수
    void GeneratePresentOnGrnd()
    {
        //선물 오브젝트 생성
        GameObject obj = Instantiate(presentOnGrnd);

        //위치 - 하늘에서 떨어진 present2가 땅과 충돌한 지점
        //       present2와 교체
        Vector3 present2Pos;
        present2Pos = this.gameObject.transform.position;

        obj.transform.position = present2Pos;
    }

}
