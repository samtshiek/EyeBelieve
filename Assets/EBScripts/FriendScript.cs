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
    bool attachControllersToHand = false;
    // Start is called before the first frame update
    void Start()
    {
        controllerL = GameObject.Find("OculusTouchForQuest2_Left");
        controllerR = GameObject.Find("OculusTouchForQuest2_Right");
        leftHand = GameObject.Find("Middle1.L");
        rightHand = GameObject.Find("Middle1.R");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(attachControllersToHand)
        {
            controllerL.transform.rotation = Quaternion.RotateTowards(controllerL.transform.rotation, Quaternion.Euler(new Vector3(270f, 35f, -330f)), 70f * Time.deltaTime);
            controllerL.transform.position = leftHand.transform.position;
            controllerL.transform.SetParent(leftHand.transform);
            controllerR.transform.rotation = Quaternion.RotateTowards(controllerR.transform.rotation, Quaternion.Euler(new Vector3(305f, 135f, 305f)), 70f * Time.deltaTime);
            controllerR.transform.position = rightHand.transform.position;
            controllerR.transform.SetParent(rightHand.transform);
        }
    }


    public void SittingComplete()
    {
       shouldPlayControllersSitting = true;
    }

    public void attachControllersToHands()
    {
        attachControllersToHand = true;
    }
}
