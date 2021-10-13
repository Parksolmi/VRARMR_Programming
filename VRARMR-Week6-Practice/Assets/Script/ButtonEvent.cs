using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEvent : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletObj;

    public VirtualButtonBehaviour behavior;

    public Material matPressed;
    public Material matRealsed;

    void Start()
    {
        behavior.RegisterOnButtonPressed(OnButtonPressed);
        behavior.RegisterOnButtonReleased(OnButtonReleased);
    }

    //��ư ���� ��
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        GetComponent<Renderer>().material = matPressed;

        //�Ѿ˹߻�
        //������
       // Shot(transform.forward);
       // Shot(-transform.forward);
        Shot(transform.right);
        Shot(-transform.right);
        Shot(transform.up);
        Shot(-transform.up);
       
    }

    //��ư �� ���� ��
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        GetComponent<Renderer>().material = matRealsed;
    }

    void Shot(Vector3 dir)
    {
        GameObject obj = Instantiate(bulletObj);
        Vector3 shotPos = transform.position + transform.up * 0.05f;

        obj.GetComponent<BulletCtrl>().SetPosDir(shotPos, dir);
        Destroy(obj, 10);
    }
}
