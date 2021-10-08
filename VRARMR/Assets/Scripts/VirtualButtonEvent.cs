using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonEvent : MonoBehaviour
{
    public GameObject player;
    public VirtualButtonBehaviour behavior;

    public Material matPressed;
    public Material matReleased;

    void Start()
    {
        behavior.RegisterOnButtonPressed(OnButtonPressed);
        behavior.RegisterOnButtonReleased(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        GetComponent<Renderer>().material = matPressed;

        player.GetComponent<Animation>().clip =
            player.GetComponent<Animation>().GetClip(vb.VirtualButtonName);
        player.GetComponent<Animation>().Play();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        GetComponent<Renderer>().material = matReleased;

        player.GetComponent<Animation>().clip =
            player.GetComponent<Animation>().GetClip("Idle");
        player.GetComponent<Animation>().Play();
    }


}
