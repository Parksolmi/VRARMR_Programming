using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//박스 오브젝트를 삭제하는 스크립트
public class RemoveBox : MonoBehaviour
{
    //충돌처리
    private void OnCollisionEnter(Collision other)
    {
        //땅
        if (other.gameObject.tag.Equals("Ground"))
        {
            //MoveBox스크립트 비활성화
            this.gameObject.GetComponent<MoveBox>().enabled = false;
            //땅에 닿으면 1초 뒤 박스 오브젝트 없애기
            Destroy(this.gameObject, 1);
        }
    }
}
