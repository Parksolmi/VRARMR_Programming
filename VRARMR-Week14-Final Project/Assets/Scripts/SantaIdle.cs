using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaIdle : MonoBehaviour
{
    public GameObject player;
    //�÷��̾ �νĵǾ����� ���θ� �����ϴ� ����
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
