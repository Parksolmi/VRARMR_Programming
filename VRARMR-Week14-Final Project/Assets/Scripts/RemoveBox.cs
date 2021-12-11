using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//박스 오브젝트를 삭제하는 스크립트
public class RemoveBox : MonoBehaviour
{
    public int deleteTime;

    //땅 위에 생성 되어 있는 선물 상자의 수
    private int presentNum;

    //충돌처리
    private void OnCollisionEnter(Collision other)
    {
        //땅
        if (other.gameObject.tag.Equals("Ground"))
        {
            if(this.tag == "Present2")
            {
                presentNum++;
            }

            if(presentNum == 5)
            {

            }

            //MoveBox스크립트 비활성화
            this.gameObject.GetComponent<MoveBox>().enabled = false;
            //땅에 닿으면 deleteTime초 뒤 박스 오브젝트 없애기
            Destroy(this.gameObject, deleteTime);
        }
    }
}
