using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//내부 포털을 움직이는 클래스
public class PortalInRotation : MonoBehaviour
{
    //회전 속도
    public float angle;

    private void Update()
    {
        //회전하기
        this.transform.Rotate(0, 0 , angle * Time.deltaTime);
    }

}
