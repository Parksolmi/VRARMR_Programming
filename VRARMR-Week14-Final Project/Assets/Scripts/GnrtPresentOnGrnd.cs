using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtPresentOnGrnd : MonoBehaviour
{
    //PresentOnGrnd 프리팹 저장 할 게임오브젝트
    public GameObject presentOnGrnd;

    //충돌처리
    private void OnCollisionEnter(Collision other)
    {
        //땅
        if (other.gameObject.tag.Equals("Ground"))
        {
            //생성
            GeneratePresentOnGrnd();
        }
    }

    //땅 위에 박스 생성
    void GeneratePresentOnGrnd()
    {
        GameObject obj = Instantiate(presentOnGrnd);

        //위치
        Vector3 present2Pos;
        present2Pos = this.gameObject.transform.position;

        obj.transform.position = present2Pos;

        //20초 뒤에 삭제
        Destroy(obj, 20);
    }
}
