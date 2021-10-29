using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMng : MonoBehaviour
{
    public TrackObj objPlayer;
    public TrackObj objMonster;

    public Text stateMsg;
    public GameObject objStartBtn;

    void Update()
    {
        if(objPlayer.isDetected && objMonster.isDetected)
        {
            if(objStartBtn.activeSelf==false)
            {
                objStartBtn.SetActive(true);
                stateMsg.text = "���� ��ư�� �����ּ���";
            }
        }

        else
        {
            if(objStartBtn.activeSelf)
            {
                objStartBtn.SetActive(false);
                stateMsg.text = "ī�带 �νĽ����ּ���";
            }
        }
    }
}
