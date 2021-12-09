using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaIdle : MonoBehaviour
{
    public GameObject player;
    //플레이어가 인식되었는지 여부를 저장하는 변수
    public bool isDetected;
    
    void Update()
    {

    }
    
    public void setActiveFalse()
    {
        player.SetActive(false);
    }

    public void OnDetect(bool detect)
    {
        isDetected = detect;
    }
}
