using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    GameObject textobject;
    Text text;
    GameObject textobject2;
    Text text2;
    GameObject doubleDoors;
    Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        textobject = GameObject.Find("MyText");
        text = (Text)textobject.GetComponent("Text");
        textobject2 = GameObject.Find("MyText2");
        text2 = (Text)textobject2.GetComponent("Text");
        doubleDoors = GameObject.Find("PFB_DoorDouble");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            text.text = "Animator variable is null!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRCameraRig")
        {
            text.text = "Entered Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            animator.enabled = true;
            animator.SetBool("isOpen_Obj_1", true);
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        text.text = "Inside Trigger";
        text2.text = "TRG: " + other.gameObject.name;
        Debug.Log("An object is still inside of the trigger");
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "OVRCameraRig")
        {
            text.text = "Exited Trigger";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object left.");
            animator.SetBool("isOpen_Obj_1", false);
        }
    }
}
