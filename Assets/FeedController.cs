using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class FeedController : MonoBehaviour
{

    GameObject textobject;
    Text text;
    GameObject textobject2;
    Text text2;
    Animator animator;
    GameObject dog;
    UnityEngine.AI.NavMeshAgent dogAgent;
    GameObject dogFood;




    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.find("Puppy_Labrador_IP");
        dogFood = GameObject.find("Food_1");
        dogFood.GetComponent<Renderer>().enabled = false;
        dogAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        textobject = GameObject.Find("MyText");
        text = (Text)textobject.GetComponent("Text");
        textobject2 = GameObject.Find("MyText2");
        text2 = (Text)textobject2.GetComponent("Text");
        animator = GetComponent<Animator>();
        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //text.text = "Entered Trigger!";
        //text2.text = "TRG: " + other.gameObject.name;

        if (other.gameObject.name == "RightHandAnchor")
        {
            text.text = "Entered Food Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            // audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            //animator.SetBool("handIsOver", true);
        }

        /* Dog pee trigger with delay
        if (other.gameObject.name == "Pee_Cube")
        {
            text.text = "Entered Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            animator.SetBool("goPee", true);
            Invoke("renderPee", 5);
        }
        */
    }

    private void renderPee()
    {
        pee.GetComponent<Renderer>().enabled = true;

    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.name == "OVRCameraRig")
        //{
        //    text.text = "Exited Trigger";
        //    text2.text = "TRG: " + other.gameObject.name;
        //    Debug.Log("An object left.");
        //    animator.SetBool("handIsOver", false);
        //}
        if (other.gameObject.name == "RightHandAnchor")
        {
            text.text = "Exited Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            animator.SetBool("handIsOver", false);
        }

        if (other.gameObject.name == "Pee_Cube")
        {
            text.text = "Exited Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            animator.SetBool("goPee", false);
        }

        if (other.gameObject.name == "OVRCameraRig")
        {
            text.text = "Exited Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            // animator.SetBool("handIsOver", false);
        }

    }
}
