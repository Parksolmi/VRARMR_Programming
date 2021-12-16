using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnrtTimeItem : MonoBehaviour
{
    //타임 아이템 프리팹 저장 할 게임오브젝트
    public GameObject timeItem;

    bool onGoing;

    // Start is called before the first frame update
    void Start()
    {
        StartGnrt();
    }

    public void StartGnrt()
    {
        onGoing = true;
        //1~3초 간격으로 랜덤 생성하기
        StartCoroutine(GenerateTimeItem());
    }

    public void StopGnrt()
    {
        onGoing = false;
        StopCoroutine(GenerateTimeItem());
    }

    IEnumerator GenerateTimeItem()
    {
        while (onGoing)
        {
            //30~40초 뒤에 다시 생성
            yield return new WaitForSeconds(Random.Range(30f, 40f));

            //아이템 상자 생성
            GameObject obj = Instantiate(timeItem);

            //아이템 상자가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.4f; //하늘에서 생성되어야 하므로 높이 고정 설정
            randPos.z = Random.Range(-0.1f, 0.1f);

            //아이템 상자 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            //아이템 상자 움직이기
            obj.GetComponent<TimeItemMove>().SetPosDir(obj.transform.position,
                                                            Vector3.down);

            //아무데도 충돌하지 않고 계속 떨어지는 경우
            Destroy(obj, 40);
        }

    }
}
