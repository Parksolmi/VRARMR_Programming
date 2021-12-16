using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtChild : MonoBehaviour
{
    //Child 프리팹 넣을 게임 오브젝트 변수
    public GameObject child;

    public float gnrtTime;

    //생성 할 어린이 수
    public int childNum;

    int gnrtNum;

    void Start()
    {
        //Child 15초 마다 한 명씩 생성
        StartCoroutine("GenerateChild");
    }

    public void StopGnrt()
    {
        StopCoroutine("GenerateChild");
    }

    IEnumerator GenerateChild()
    {
        gnrtNum = childNum;

        while (gnrtNum > 0)
        {
            Debug.Log(gnrtNum);

            //gnrtTime초 뒤에 생성
            yield return new WaitForSeconds(gnrtTime);

            //생성
            GameObject obj = Instantiate(child);

            //생성 위치
            //Child가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Child가 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            gnrtNum--;
        }
    }

}
