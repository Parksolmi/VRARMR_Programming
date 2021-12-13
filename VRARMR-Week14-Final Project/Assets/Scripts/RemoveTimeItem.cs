using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        stage = GameObject.FindGameObjectWithTag("Stage2");
    }


    //충돌검사
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Santa2")
        {
            Destroy(this.gameObject);
            stage.GetComponent<Mng_Score>().PlusCountDown(plusTime);
        }
        if (other.tag == "Ground")
        {
            //TimeItemMove 비활성화
            this.gameObject.GetComponent<TimeItemMove>().enabled = false;
            //땅에 닿으면 deleteTime초 뒤 박스 오브젝트 없애기
            Destroy(this.gameObject, deleteTime);
        }
    }
}
