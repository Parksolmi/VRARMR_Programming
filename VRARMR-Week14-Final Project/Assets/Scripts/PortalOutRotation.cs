using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOutRotation : MonoBehaviour
{
    //회전 속도
    public float angle;

    private void Update()
    {
        this.transform.Rotate(0, 0, -angle * Time.deltaTime);
    }

}
