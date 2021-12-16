using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//박스 오브젝트를 삭제하는 스크립트
public class RemoveBox : MonoBehaviour
{
    public float deleteTime; //삭제 될 시간

    //충돌처리
    private void OnTriggerEnter(Collider other)
    {
        //땅과 충돌 한 경우
        if (other.gameObject.tag.Equals("Ground"))
        {
            //MoveBox스크립트 비활성화
            this.gameObject.GetComponent<MoveBox>().enabled = false;
            //땅에 닿으면 deleteTime초 뒤 박스 오브젝트 없애기
            Destroy(this.gameObject, deleteTime);
        }
    }
}
