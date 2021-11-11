using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform camTr;

    void LateUpdate()
    {
        transform.LookAt(camTr.position, Vector3.up);

    }
}
