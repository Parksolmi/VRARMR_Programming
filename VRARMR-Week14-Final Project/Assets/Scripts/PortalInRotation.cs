using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInRotation : MonoBehaviour
{
    //ȸ�� �ӵ�
    public float angle;

    private void Update()
    {
        this.transform.Rotate(0, 0 , angle * Time.deltaTime);
    }

}
