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
    GameObject pee;
    public float rotationSpeed;
    public float speed;
    GameObject bedObject;
    StoryScript storyScript;

    // Start is called before the first frame update
    void Start()
    {
        bedObject = GameObject.Find("PFB_Bed");
        storyScript = bedObject.GetComponent<StoryScript>();
        dog = gameObject;
        pee = GameObject.Find("DogPee");
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }


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

    private void OnTriggerStay(Collider other)
    {
        text.text = "Entered Trigger!";
        //text2.text = "TRG: " + other.gameObject.name;

        if (other.gameObject.name == "RightHandAnchor")
        {
            //text.text = "Entered Trigger!";
            //text2.text = "TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            // audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            animator.SetBool("handIsOver", true);
        }


        if (other.gameObject.name == "Pee_Cube")
        {
            text.text = "Dog Entered Entered!";
            text2.text = "Dog Pee TRG: " + other.gameObject.name;
            Debug.Log("An object entered.");
            animator.SetBool("goPee", true);
           // Invoke("renderPee", 5);
        }

    }

    private void renderPee()
    {
        pee.GetComponent<Renderer>().enabled = true;
        animator.SetBool("goPee", false);

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
            storyScript.setPet(true);
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
