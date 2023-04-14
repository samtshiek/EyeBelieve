using Meta.WitAi.TTS.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        GameObject textobject = GameObject.Find("MyText");
        GameObject ttsObject = GameObject.Find("TTSSpeaker");

        if (OVRInput.Get(OVRInput.Button.One))
        {
            if (textobject)
            {
                Text text = (Text)textobject.GetComponent("Text");

                TTSSpeaker tTSSpeaker = (TTSSpeaker)ttsObject.GetComponent("TTSSpeaker");
                tTSSpeaker.Speak("Hello, finally");
                text.text = "Here is another one...";

                Debug.Log("Here is its type: " + textobject.tag);
            }

            Debug.Log("Button press registered!!");
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            Text text = (Text)textobject.GetComponent("Text");
            UAP_AccessibilityManager.EnableAccessibility(true);
            UAP_AccessibilityManager.Say("Hello, mister!");


            text.text = "Here is another one...";

            Debug.Log("Here is its type: " + textobject.tag);
        }
        
    }

}
