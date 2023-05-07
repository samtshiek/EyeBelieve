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
    bool Eidle = false;
    bool Ewalking = false;
    bool Etrotting = false;
    bool Erunning = false;
    public AudioSource audioSource;



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
        if (animator == null)
        {
        //    text.text = "Animator variable is null!";
        }

     //   text.text = "Vel" + dogAgent.velocity.magnitude;
       // text2.text = "Steer: " + dogAgent.transform.rotation;

        if (dogAgent.velocity.magnitude == 0 && Eidle == false)
        {
            Eidle = true;
            animator.SetBool("walking", false);
        }

        if (dogAgent.velocity.magnitude > 0 && dogAgent.velocity.magnitude < 1 && Ewalking == false)
        {
            Eidle = false;
            Ewalking = true;
            animator.SetBool("walking", true);
            animator.SetBool("trotting", false);
        }

        if (dogAgent.velocity.magnitude >= 1 && dogAgent.velocity.magnitude < 1.5 && Etrotting == false)
        {
            Ewalking = false;
            Etrotting = true;
            Erunning = false;
            animator.SetBool("trotting", true);
            animator.SetBool("running", false);
        }

        if (dogAgent.velocity.magnitude >= 1.5 && Erunning == false)
        {
            Etrotting = false;
            Erunning = true;
            animator.SetBool("running", true);
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "OVRCameraRig")
        //{
        //    text.text = "Entered Trigger!";
        //    text2.text = "TRG: " + other.gameObject.name;
        //}
        //if (other.gameObject.name == "RightHandAnchor" || other.gameObject.name == "LeftHandAnchor")
        if (other.gameObject.name == "RightHandAnchor")
        {
            text.text = "Entered Trigger!";
            text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
           // audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            animator.SetBool("handIsOver", true);
        }

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
            animator.SetBool("handIsOver",false);
        }

    }
}
