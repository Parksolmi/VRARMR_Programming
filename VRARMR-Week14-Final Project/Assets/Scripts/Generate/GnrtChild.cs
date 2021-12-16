using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage3에 등장하는 Child 오브젝트를 생성하는 클래스
public class GnrtChild : MonoBehaviour
{
    //Child 프리팹 넣을 게임 오브젝트 변수
    public GameObject child;

    //Child 프리팹 저장 할 리스트
    List<GameObject> childList = new List<GameObject>();

    //생성 시간
    public float gnrtTime;

    //생성 할 전체 Child 수
    public int childNum;

    //생성 한 child 수
    int gnrtNum;

    //getter & setter
    public int GetChildNum()
    {
        return childNum;
    }

    void Start()
    {
        //Child를 15초 마다 한 명씩 생성
        StartCoroutine("GenerateChild");
    }

    //코루틴 함수를 종료하는 함수
    public void StopGnrt()
    {
        StopCoroutine("GenerateChild");
    }

    //Child를 생성하는 함수
    IEnumerator GenerateChild()
    {
        gnrtNum = 0; //gnrtNum을 0으로 초기화
        int index = 0;

        while (gnrtNum != childNum) //gnrtNum이 childNum과 같아질 때까지
        {
            //gnrtTime초 뒤에 생성 (대기)
            yield return new WaitForSeconds(gnrtTime);

            //Child 생성
            GameObject obj = Instantiate(child);
            //리스트에 추가
            childList.Insert(index++, obj);

            //생성 위치
            //Child가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Child가 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            //생성된 child수 증가시키기
            gnrtNum++;
        }
    }

    //리스트에 저장된 오브젝트 모두 지우는 함수
    public void DeleteList()
    {
        for(int i=0; i< gnrtNum; i++)
        {
            Destroy(childList[i]);
        }
    }
}