using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 시작 전 플레이어 캐릭터에 대한 클래스
public class SantaIdle : MonoBehaviour
{
    //플레이어를 저장할 게임 오브젝트 변수
    public GameObject player;
    //플레이어가 인식되었는지 여부를 저장하는 변수
    public bool isDetected;
    
    //해당 게임 오브젝트를 비활성화 시키는 함수
    public void setActiveFalse()
    {
        player.SetActive(false);
    }

    //해당 플레이어가 인식되었는지 확인하는 함수
    public void OnDetect(bool detect)
    {
        //인식되었다면 true를, 인식되지 않았다면 false를 변수에 저장
        isDetected = detect;
    }
}
