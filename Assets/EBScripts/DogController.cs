using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    GameObject textobject;
    Text text;
    GameObject textobject2;
    Text text2;
    Animator animator;
    GameObject dog;
    NavMeshAgent dogAgent;
    bool idle = false;
    bool walking = false;
    bool trotting = false;
    bool running = false;
    public AudioSource audioSource;
    int runningCount = 0;



    // Start is called before the first frame update
    void Start()
    {
        dog = gameObject;
        dogAgent = GetComponent<NavMeshAgent>();
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

    private void FixedUpdate()
    {
        if (animator == null)
        {
        //    text.text = "Animator variable is null!";
        }

     //   text.text = "Vel: " + dogAgent.velocity.magnitude;
     //   text2.text = "State: " + animator.GetCurrentAnimatorStateInfo(0);

       /* if (animator.GetBool("walking") == true)
        {
            text2.text = "walking";
        }

        else
        {
            text2.text = "idle";
        }

        if (animator.GetBool("trotting") == true)
        {
            text2.text = "trotting";
        }

        if (animator.GetBool("running") == true)
        {
            text2.text = "running";
        } */

        if (dogAgent.velocity.magnitude == 0.0 && idle == false)
        {
            //animator.GetCurrentAnimatorStateInfo(0);
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

        /*if (dogAgent.velocity.magnitude == 0.0)
        {
            //animator.GetCurrentAnimatorStateInfo(0);
            if (walking)
            {
                animator.SetTrigger("Walk to Idle");
                idle = true;
                walking = false;
            }
        }

        if (dogAgent.velocity.magnitude > 0.0 && dogAgent.velocity.magnitude < 0.3)
        {
            if (trotting)
            {
                animator.SetTrigger("Trot to Walk");
                walking = true;
                trotting = false;
            }

            else
            {
                animator.SetTrigger("Idle to Walk");
                walking = true;
                idle = false;
            }
            
        }

        if (dogAgent.velocity.magnitude >= 0.3 && dogAgent.velocity.magnitude < 0.5)
        {
            if (running)
            {
                animator.SetTrigger("Run to Trot");
                running = false;
            }
            else
            {
                animator.SetTrigger("Walk to Trot");
                trotting = true;
                walking = false;
            }
        }

        if (dogAgent.velocity.magnitude >= 0.5)
        {
            animator.SetTrigger("Trot to Run");
            running = true;
            trotting = false;
        }*/
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "RightHandAnchor")
        {
            text.text = "Entered Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            // audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            animator.SetBool("handIsOver", true);
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (other.gameObject.name == "OVRCameraRig")
    //    //{
    //    //    text.text = "Entered Trigger!";
    //    //    text2.text = "TRG: " + other.gameObject.name;
    //    //}
    //    //if (other.gameObject.name == "RightHandAnchor" || other.gameObject.name == "LeftHandAnchor")
    //    if (other.gameObject.name == "RightHandAnchor")
    //    {
    //        text.text = "Entered Trigger!";
    //        text2.text = "TRG: " + other.gameObject.name;
    //        Debug.Log("An object entered.");
    //       // audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
    //        animator.SetBool("handIsOver", true);
    //    }

    //}

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

    }
}
