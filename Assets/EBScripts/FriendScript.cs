using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScript : MonoBehaviour
{
    public bool shouldRotate = false;
    public bool shouldSit = false;
    public bool shouldPlayControllersSitting = false;
    GameObject controllerL;
    GameObject controllerR;
    GameObject rightHand;
    GameObject leftHand;
    // Start is called before the first frame update
    void Start()
    {
        controllerL = GameObject.Find("OculusTouchForQuest2_Left");
        controllerR = GameObject.Find("OculusTouchForQuest2_Right");
        leftHand = GameObject.Find("Hand.R");
        rightHand = GameObject.Find("Hand.L");
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldPlayControllersSitting)
        {
            controllerL.transform.position = leftHand.transform.position;
            controllerL.transform.SetParent(leftHand.transform);
            controllerR.transform.position = rightHand.transform.position;
            controllerR.transform.SetParent(rightHand.transform);
        }
        
    }

    public void SittingComplete()
    {
       shouldPlayControllersSitting = true;
    }
}
