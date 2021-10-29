using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMgr : MonoBehaviour
{
    Camera ARCam;

    void Start()
    {
        ARCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = ARCam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, 1 << 8))
            {
                GameObject canvas = hit.transform.Find("Canvas").gameObject;
                canvas.SetActive(!canvas.activeSelf);
            }
        }
    }
}
