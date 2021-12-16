using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeOut : MonoBehaviour
{
    //스테이지 저장 할 게임 오브젝트
    GameObject stage;

    bool isTimeOut;

    public bool GetIsTimeOut()
    {
        return isTimeOut;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.FindGameObjectWithTag("Stage2");

        isTimeOut = true;

        StartCoroutine(PlusScore());
    }

    //충돌 검사
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemySanta")
        {
            isTimeOut = false;
        }
    }

    IEnumerator PlusScore()
    {
        yield return new WaitForSeconds(15f);

        if (isTimeOut)
        {
            stage.GetComponent<Mng_Score>().AddScore(1);
        }

        //오브젝트 삭제
        Destroy(this.gameObject);
    }
}
