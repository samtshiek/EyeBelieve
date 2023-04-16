using Meta.WitAi.TTS.Utilities;
using Meta.WitAi.TTS.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        GameObject oVRCameraRig = GameObject.Find("OVRCameraRig");
        GameObject centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        GameObject textobject = GameObject.Find("MyText");
        Text text = (Text)textobject.GetComponent("Text");

        //Button A pressed
        if (OVRInput.Get(OVRInput.Button.One))
        {
            text.text = "'A' button.";
            GameObject rawImageObject = GameObject.Find("RawImage");
            rawImageObject.active = true;
        }

        //Button B pressed
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            text.text = "'B' button.";
            GameObject rawImageObject = GameObject.Find("RawImage");
            rawImageObject.active = false;
        }

        //Right Thumbstick pushed up
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
;
            text.text = "Forward: " + oVRCameraRig.transform.forward;
            oVRCameraRig.transform.position += new Vector3(centerEyeAnchor.transform.forward.x/50, 0, centerEyeAnchor.transform.forward.z/50);
        }

        //Right Thumbstick pushed down
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            text.text = "Rotation: " + oVRCameraRig.transform.rotation;
        }


        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            text.text = "P Thumbstick UP' button.";
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            text.text = "P Thumbstick DOWN' button.";
        }

        /*GameObject ttsObject = GameObject.Find("TTSSpeaker");

        GameObject oVRCameraRig = GameObject.Find("OVRCameraRig");
        
        
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            UAP_AccessibilityManager.UseAndroidTTS();
            UAP_AccessibilityManager.EnableAccessibility(true, false);
            UAP_AccessibilityManager.Say("Executed!");

            Transform transform = (Transform)oVRCameraRig.GetComponent("Transform");
            transform.localPosition += new Vector3(0, 0, transform.localPosition.y + 1);
            text.text = "forward: " + transform.position.y;

        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            UAP_AccessibilityManager.EnableAccessibility(true, false);
            UAP_AccessibilityManager.UseAndroidTTS();
            UAP_AccessibilityManager.Say("Working.");
            Transform transform = (Transform)oVRCameraRig.GetComponent("Transform");
            transform.localPosition += new Vector3(0, 0, transform.localPosition.y - 1);
            text.text = "backwards: " + transform.position.y;

        }

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).magnitude != 0)
        {
            text.text = "Primary Thumbstick: " + OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).magnitude;
        }

        if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude != 0)
        {
            text.text = "Secondary Thumbstick: " + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).magnitude;
        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.0) 
        {
            text.text = "PrimaryIndexTrigger";
         
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0)
        {

            TTSSpeaker tTSSpeaker = (TTSSpeaker)ttsObject.GetComponent("TTSSpeaker");
            tTSSpeaker.Speak("Hello, finally");
            tTSSpeaker.SpeakAsync("Hello there");

            text.text = "SecondaryIndexTrigger";
        }*/

    }

  /*  private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        GameObject oVRCameraRig = GameObject.Find("OVRCameraRig");
        GameObject textobject = GameObject.Find("MyText");
        Text text = (Text)textobject.GetComponent("Text");
        text.text = "Rig location: " + oVRCameraRig.transform.localPosition.y;

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            UAP_AccessibilityManager.EnableAccessibility(true, false);
            UAP_AccessibilityManager.Say("WORKIN!");
            oVRCameraRig.transform.position += new Vector3(0, 0, transform.localPosition.y + 1);
            text.text = "forward: " + transform.position.y;

        }

        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            UAP_AccessibilityManager.EnableAccessibility(true, false);
            UAP_AccessibilityManager.Say("WORKIN!");
            oVRCameraRig.transform.position += new Vector3(0, 0, transform.localPosition.y - 1);
            text.text = "backwards: " + transform.position.y;

        }
    }*/


}
