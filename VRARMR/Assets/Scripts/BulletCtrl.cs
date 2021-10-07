using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCtrl : MonoBehaviour
{ 
    public Text buttonText;
    public GameObject bulletObj;


    public void OnClickButton1(string name)
    { 
        Shot((transform.forward + transform.right) / 2.0f);
        Shot((transform.forward + (-transform.right)) / 2.0f);
        buttonText.text = name;
    }

    public void OnClickButton2(string name)
    {
        Shot(((-transform.forward) + transform.right) / 2.0f);
        Shot(((-transform.forward) + (-transform.right)) / 2.0f);
        buttonText.text = name;
    }

    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletMove>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }
}
