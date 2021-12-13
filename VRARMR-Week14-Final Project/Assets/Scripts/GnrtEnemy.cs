using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy 산타 생성하는 스크립트
public class GnrtEnemy : MonoBehaviour
{
    //Enemy Santa 프리팹 저장
    public GameObject enemy;

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
        StartCoroutine(GenerateEnemy());
    }

    public void StopGnrt()
    {
        onGoing = false;
        StopCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {
        while(onGoing)
        {
            //10초 뒤에 다시 생성
            yield return new WaitForSeconds(10f);

            //생성
            GameObject obj = Instantiate(enemy);

            //생성 위치
            //Enemy가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.2f, 0.2f);
            randPos.y = 0;
            randPos.z = Random.Range(-0.2f, 0.2f);

            //Enemy 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            
        }
        
    }
}
