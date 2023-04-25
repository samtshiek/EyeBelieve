using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikeChController : MonoBehaviour
{

    GameObject ovrCameraRig;
    GameObject centerEyeAnchor;
    CharacterController characterController;
    int acceleration = 0;
    float gravity = 9.8f;
    // Start is called before the first frame update
    void Start()
    {
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            characterController.Move(new Vector3(centerEyeAnchor.transform.forward.x / (50 - acceleration), (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / (50 - acceleration)));
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0)
        {
            acceleration = 40;
        }
        else
        {
            acceleration = 0;
        }
    }
}
