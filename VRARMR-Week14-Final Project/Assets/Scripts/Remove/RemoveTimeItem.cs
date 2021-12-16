using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//시간 아이템을 삭제하는 클래스
public class RemoveTimeItem : MonoBehaviour
{
    //스테이지 게임 오브젝트 저장하는 변수
    private GameObject stage;

    //아이템 획득 시 늘어나는 시간
    public int plusTime;
    //땅에 닿은 후 사라지는 시간
    public float deleteTime;

    private void Start()
    {
        //스테이지 변수 설정
        stage = GameObject.FindGameObjectWithTag("Stage2");
    }

    //충돌검사
    private void OnTriggerEnter(Collider other)
    {
        //플레이어와 충돌 한 경우
        if (other.tag == "Santa2")
        {
            Destroy(this.gameObject); //아이템 삭제
            stage.GetComponent<Mng_Score>().PlusCountDown(plusTime); //시간 증가
        }
        //땅과 충돌 한 경우
        if (other.tag == "Ground")
        {
            //TimeItemMove 비활성화
            this.gameObject.GetComponent<TimeItemMove>().enabled = false;
            //땅에 닿으면 deleteTime초 뒤 아이템 오브젝트 없애기
            Destroy(this.gameObject, deleteTime);
        }
    }
}
