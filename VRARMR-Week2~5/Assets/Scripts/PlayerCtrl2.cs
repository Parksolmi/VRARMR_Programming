using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl2 : MonoBehaviour
{
    enum State
    {
        Move,
        Spin,
        Zoom
    }

    public Text stateText;

    Vector3 prePos;

    State curState = State.Move;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 deltaPos = Input.mousePosition - prePos;

            switch (curState)
            {
                case State.Move:
                    deltaPos *= (Time.deltaTime * 0.1f);
                    transform.Translate(0, deltaPos.y, 0, Space.World);
                    break;

                case State.Spin:
                    deltaPos *= (Time.deltaTime * 10);
                    transform.Rotate(0, 0, -deltaPos.x, Space.World);
                    break;

                case State.Zoom:
                    deltaPos *= (Time.deltaTime * 0.1f);
                    transform.localScale += deltaPos;
                    break;
            }
            
        }
        prePos = Input.mousePosition;
    }

    public void OnClickMove(string name)
    {
        curState = State.Move;
        stateText.text = name;
    }

    public void OnClickSpin(string name)
    {
        curState = State.Spin;
        stateText.text = name;
    }

    public void OnClickZoom(string name)
    {
        curState = State.Zoom;
        stateText.text = name;
    }
}
