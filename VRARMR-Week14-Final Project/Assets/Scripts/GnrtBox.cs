using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상자(선물/쓰레기통) 생성하는 함수
public class GnrtBox : MonoBehaviour
{
    //상자 오브젝트
    public GameObject present; //선물상자
    public GameObject woodBox; //나무상자

    //선물 상자 나오는 확률
    float rate = 0.5f;

    void Start()
    {
        //3초 후에 1~3초 간격으로 랜덤 생성하기
        InvokeRepeating("GenerateBox", 3, Random.Range(1, 3));
    }

    void Update()
    {
        
    }

    //박스 생성 함수
    void GenerateBox()
    {
        //선물 상자가 나오는 경우 - 확률 : 60%
        if(Random.Range(0.0f, 1.0f) < rate)
        {
            //선물상자 생성
            GameObject obj = Instantiate(present);

            //선물 상자가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.4f; //하늘에서 생성되어야 하므로 높이 고정 설정
            randPos.z = Random.Range(-0.1f, 0.1f);

            //선물 상자 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;
            
            //선물 상자 움직이기
            obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position, 
                                                            Vector3.down);
            
        }
        //나무 상자가 나오는 경우 - 확률 : 40%
        else //wood box
        {
            //나무 상자 생성
            GameObject obj = Instantiate(woodBox);

            //나무 상자가 생성되는 랜덤 위치 설정
            Vector3 randPos;
            randPos.x = Random.Range(-0.1f, 0.1f);
            randPos.y = 0.4f; //하늘에서 생성되어야 하므로 높이 고정 설정
            randPos.z = Random.Range(-0.1f, 0.1f);

            //나무 상자 위치 = 플레이어 위치에서 랜덤 위치를 더한 값
            obj.transform.position = transform.position + randPos;

            //나무 상자 움직이기
            obj.GetComponent<MoveBox>().SetPosDir(obj.transform.position,
                                                            Vector3.down);

        }
        
    }
}
