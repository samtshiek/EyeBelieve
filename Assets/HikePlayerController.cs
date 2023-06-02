using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Oculus.Interaction.HandGrab;
using System.Collections;

public class HikePlayerController : MonoBehaviour
{
    GameObject oVRCameraRig;
    GameObject centerEyeAnchor;
    CharacterController charController;
    float gravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        oVRCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        charController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();




        //Button A pressed
        if (OVRInput.Get(OVRInput.Button.One))
        {
      
        }


        //Button Y pressed
        if (OVRInput.Get(OVRInput.Button.Four))
        {
           
        }



        //Button B pressed
        if (OVRInput.Get(OVRInput.Button.Two))
        {
       
        }

        //Right Thumbstick pushed up
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / 30, (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / 50));

        }


        //Right Thumbstick pushed down
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / (-30), (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / (-50)));
        }


        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {

        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {

        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0)
        {
        

        }

        //Right hand trigger pushed
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.0)
        {
 
        }

       

        if (Input.GetKeyDown(KeyCode.Equals))
        {
       
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}

