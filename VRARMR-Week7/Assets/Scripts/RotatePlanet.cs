using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public Transform targetTr;
    public float rotSpeed;

    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.RotateAround(targetTr.position, Vector3.up, 
            Time.deltaTime * rotSpeed);
    }

    public void OnTargetFound()
    {
        print("Ÿ�� �̹��� �߰�");
        //enabled = true; //enabled : ��ũ��Ʈ�� ���� �� �� �ִ� ����
        gameObject.SetActive(true);
    }

    public void OnTargetLost()
    {
        print("Ÿ�� �̹��� ����");
        //enabled = false;
        gameObject.SetActive(false);
    }
}
