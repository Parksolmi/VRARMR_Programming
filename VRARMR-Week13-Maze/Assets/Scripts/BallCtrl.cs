using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour
{
    public Transform camTr;
    Rigidbody rb;

    Vector3 firstPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstPos = transform.localPosition;
    }

    void Update()
    {
        Physics.gravity = camTr.up * -0.5f;
    }

    public void OnFound()
    {
        if(rb!=null)
        {
            rb.isKinematic = false;
        }
    }

    public void OnLost()
    {
        if(rb!=null)
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objName = collision.gameObject.name;

        if (objName == "Item")
        {
            collision.gameObject.SetActive(false);
            print("æ∆¿Ã≈€ »πµÊ");
        }
        else if (objName == "Exit")
        {
            GameMng.instance.GoNextStage();
        }
        else if(objName == "Trap")
        {
            transform.localPosition = firstPos;
        }
    }
}
