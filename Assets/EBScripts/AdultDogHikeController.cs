using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdultDogHikeController : MonoBehaviour
{
    Animator animator;
    GameObject dog;
    NavMeshAgent dogAgent;
    bool idle = false;
    bool walking = false;
    bool trotting = false;
    bool running = false;
    public AudioSource audioSource;
    int runningCount = 0;
    public float rotationSpeed;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        dog = gameObject;
        dogAgent = GetComponent<NavMeshAgent>();
        // textobject = GameObject.Find("MyText");
        //  text = (Text)textobject.GetComponent("Text");
        // textobject2 = GameObject.Find("MyText2");
        //  text2 = (Text)textobject2.GetComponent("Text");
        animator = GetComponent<Animator>();
        animator.enabled = true;
        //   dog.GetComponent<Renderer>().enabled = false;



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (dogAgent.velocity.magnitude == 0.0 && idle == false)
        {
            animator.SetBool("walking", false);
            animator.SetBool("trotting", false);
            animator.SetBool("running", false);
            idle = true;
            walking = false;
            trotting = false;
            running = false;
        }

        if (dogAgent.velocity.magnitude > 0.0 && dogAgent.velocity.magnitude < 0.3 && walking == false)
        {
            if (animator.GetBool("walking") == false)
            {
                animator.SetBool("walking", true);
            }
            else
            {
                animator.SetBool("running", false);
                animator.SetBool("trotting", false);
            }

            idle = false;
            walking = true;
            trotting = false;
            running = false;
        }
        if (dogAgent.velocity.magnitude >= 0.3 && dogAgent.velocity.magnitude < 0.5 && trotting == false)
        {
            if (animator.GetBool("trotting") == false)
            {
                animator.SetBool("walking", true);
                animator.SetBool("trotting", true);
            }
            else
            {
                animator.SetBool("running", false);
            }

            idle = false;
            walking = false;
            trotting = true;
            running = false;
        }

        if (dogAgent.velocity.magnitude >= 0.5 && running == false)
        {
            if (animator.GetBool("running") == false)
            {
                animator.SetBool("walking", true);
                animator.SetBool("trotting", true);
                animator.SetBool("running", true);
            }

            idle = false;
            walking = false;
            trotting = false;
            running = true;
            ++runningCount;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //text.text = "Entered Trigger!";
        //text2.text = "TRG: " + other.gameObject.name;

        if (other.gameObject.name == "RightHandAnchor")
        {
            //text.text = "Entered Trigger!";
            //text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            // audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            animator.SetBool("handIsOver", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RightHandAnchor")
        {
            animator.SetBool("handIsOver", false);
            
        }
    }
}
