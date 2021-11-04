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

    Animation objAni;

    void Start()
    {
        InitInfo();
        objAni = GetComponent<Animation>();
    }

    public void InitInfo()
    {
        infoTM.text = objName + "\n HP: " + hp;
    }

    public void OnDetect(bool detect)
    {
        isDetected = detect;
    }

    public float PlayAnimation(string clipName)
    {
        if(objAni.GetClip(clipName) == null)
        {
            clipName = name + "_" + clipName;
        }

        objAni.Play(clipName);

        return objAni.GetClip(clipName).length;
    }
}
