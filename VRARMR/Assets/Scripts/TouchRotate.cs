using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public Space mySpace;

    Vector3 prePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 deltaPos = Input.mousePosition - prePos;
            deltaPos *= (Time.deltaTime * 10);

            transform.Rotate(deltaPos.y, -deltaPos.x, 0, mySpace);

        }

        prePos = Input.mousePosition;
    }
}
