using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class FeedController : MonoBehaviour
{

   // GameObject textobject;
  //  Text text;
   // GameObject textobject2;
  //  Text text2;
    Animator animator;
    public GameObject dog;
    public NavMeshAgent dogAgent;
    GameObject dogFood;
    GameObject dogBowl;
    public Animator dogAnimator;
    bool closeToBowl;
    GameObject bedObject;
    StoryScript storyScript;
    AudioSource audioSource;
    bool timeToEat = false;
    GameObject oVRAudioSourceObject;
    AudioSource ovrAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        bedObject = GameObject.Find("PFB_Bed");
        storyScript = bedObject.GetComponent<StoryScript>();
        dog = GameObject.Find("Puppy_Labrador_IP");
        dogAnimator = dog.GetComponent<Animator>();
        dogAnimator.enabled = true;
        dogBowl = GameObject.Find("Bowl_2_food_1");
        dogFood = GameObject.Find("Food_1");
        dogFood.GetComponent<Renderer>().enabled = false;
        dogAgent = dog.GetComponent<NavMeshAgent>();
      //  textobject = GameObject.Find("MyText");
      //  text = (Text)textobject.GetComponent("Text");
      //  textobject2 = GameObject.Find("MyText2");
     //   text2 = (Text)textobject2.GetComponent("Text");
        animator = dog.GetComponent<Animator>();
        animator.enabled = true;
        audioSource = dogBowl.GetComponent<AudioSource>();
        oVRAudioSourceObject = GameObject.Find("OVRAudioSource");
        ovrAudioSource = oVRAudioSourceObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame

    void FixedUpdate()
    {
        //text.text = "D: " + dogAgent.remainingDistance;
        //dogAgent.stoppingDistance = 0.5f;
        if (Vector3.Distance(dog.transform.position, dogBowl.transform.position) < 0.5 && timeToEat)
        {
            closeToBowl = true;          
        }

        dogEat();
    }

    private void dogEat()
    {
        if (closeToBowl) 
        {
            if (dogAnimator == null)
            {
                Debug.Log("DOG ANIMATOR NULL!!!!!!!!!");
            }
            else
            {
                dogAnimator.SetBool("dogEating", true);
                closeToBowl = false;
                timeToEat = false;
                Invoke("doneEating", 5);
            }
            
        }

    }

    private void doneEating()
    {
        dogFood.GetComponent<Renderer>().enabled = false;
        dogAnimator.SetBool("dogEating", false);
        storyScript.setFeed(true);
        dogAgent.stoppingDistance = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bowl_2_food_1" /*"RightHandAnchor"*/)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //text.text = "Entered Trigger!";
        //text2.text = "TRG: " + other.gameObject.name;

        if (other.gameObject.name == "Bowl_2_food_1" /*"RightHandAnchor"*/)
        {
            //  text.text = "Entered Food Trigger!";
            //  text2.text = "TRG: " + other.gameObject.name;

            timeToEat = true;
            Debug.Log("An object entered.");
            dogFood.GetComponent<Renderer>().enabled = true;
            dogAgent.stoppingDistance = 1.55f;

            if(gameObject.name == "Labrador_Adult")
            {
                dogAgent.stoppingDistance = 0.1f;
            }
            dogAgent.SetDestination(dogBowl.transform.position); //dogAgent.SetDestination(dogBowl.transform.position + new Vector3(0,0,0.26f));
            if (!ovrAudioSource.isPlaying)
            {
                ovrAudioSource.PlayOneShot(Resources.Load<AudioClip>("Joe Recs/Joe 4 time"));
            }
            //Invoke("dogEat", 4);
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

    

    /*private void renderPee()
    {
        pee.GetComponent<Renderer>().enabled = true;

    }*/

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
          //  text.text = "Exited Trigger!";
          //  text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            dogAnimator.SetBool("dogEating", false);
        }

        if (other.gameObject.name == "Pee_Cube")
        {
          //  text.text = "Exited Trigger!";
         //   text2.text = "TRG: " + other.gameObject.name;
            UnityEngine.Debug.Log("An object entered.");           
        }

        if (other.gameObject.name == "OVRCameraRig")
        {
         //   text.text = "Exited Trigger!";
         //   text2.text = "TRG: " + other.gameObject.name;
         //   Debug.Log("An object entered.");
            // animator.SetBool("handIsOver", false);
        }

    }
}
