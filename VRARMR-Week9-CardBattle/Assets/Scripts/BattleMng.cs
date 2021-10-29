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
                stateMsg.text = "시작 버튼을 눌러주세요";
            }
        }

        else
        {
            if(objStartBtn.activeSelf)
            {
                objStartBtn.SetActive(false);
                stateMsg.text = "카드를 인식시켜주세요";
            }
        }
    }
}
