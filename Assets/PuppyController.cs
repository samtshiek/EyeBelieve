using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuppyController : MonoBehaviour
{
    GameObject puppyDog;
    Animator animator;
    Text text;
    Text text2;
    //Bool handIsOver;

  
    // Start is called before the first frame update
    void Start()
    {
        puppyDog = GameObject.Find("Puppy_Labrador_IP");
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
            animator.SetBool("handIsOver", true);
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
            animator.SetBool("handIsOver", false);
        }
    }
}
