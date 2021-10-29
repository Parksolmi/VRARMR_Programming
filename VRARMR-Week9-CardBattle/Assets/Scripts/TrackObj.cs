using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObj : MonoBehaviour
{
    public TextMesh infoTM;

    public string objName;
    public int hp;
    public int atk;
    public int def;

    public bool isDetected;

    void Start()
    {
        InitInfo();
    }

    public void InitInfo()
    {
        infoTM.text = objName + "\n HP: " + hp;
    }

    public void OnDetect(bool detect)
    {
        isDetected = detect;
    }
}
