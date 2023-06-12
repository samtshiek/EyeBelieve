using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Oculus.Interaction.HandGrab;
using System.Collections;

public class HikePlayerController : MonoBehaviour
{
    GameObject oVRCameraRig;
    GameObject centerEyeAnchor;
    CharacterController charController;
    public AudioSource audioSource;
    float gravity = 9.8f;
    GameObject adultDog;
    NavMeshAgent adultDogAgent;
    public Vector3 nextLocation;
    bool pauseHike = true;
    GameObject handGrab;
    HandGrabInteractor handGrabInteractor;
    HandGrabInteractable grabbedObjectR = null;
    int handEmptyR = 0;
    public ParticleSystem explosion;
    int frameWithKey = 1;
    GameObject block1;
    GameObject block2;
    GameObject block3;


    // Start is called before the first frame update
    void Start()
    {
        oVRCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        charController = GetComponent<CharacterController>();
        adultDog = GameObject.Find("Labrador");
        adultDogAgent = adultDog.GetComponent<NavMeshAgent>();
        handGrab = GameObject.Find("HandGrabInteractorR");
        handGrabInteractor = handGrab.GetComponent<HandGrabInteractor>();
        nextLocation = new Vector3(108.34870910644531f, 97.697998046875f, 225.53494262695313f);
        block1 = GameObject.Find("Block1");
        block2 = GameObject.Find("Block2");
        block3 = GameObject.Find("Block3");
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        if (!pauseHike)
        {
            startHike();
        }

        //Button A pressed
        if (OVRInput.Get(OVRInput.Button.One))
        {
            pauseHike = false;
            startHike();
        }


        //Button Y pressed
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            pauseHike = true;
            adultDogAgent.isStopped = true;
        }



        //Button B pressed
        if (OVRInput.Get(OVRInput.Button.Two))
        {
       
        }

        //Right Thumbstick pushed up
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / 20, (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / 20));

        }


        //Right Thumbstick pushed down
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / (-20), (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / (-20)));
        }


        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {

        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {

        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0)
        {
            
        }

        //Right hand trigger pushed
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Joe Recs/Joe 2 come boy"));
                Invoke("CallDog", 1f);
            }
        }

       

        if (Input.GetKeyDown(KeyCode.Equals))
        {
       
        }
    }

    private void startHike()
    {
        if (Vector3.Distance(gameObject.transform.position, adultDog.transform.position) < 10f)
        {
            if (Vector3.Distance(gameObject.transform.position, adultDog.transform.position) < 2f)
            {
                adultDogAgent.isStopped = false;
                adultDogAgent.SetDestination(nextLocation);
            }
        }

        else
        {
            adultDogAgent.isStopped = true;
        }
    }

    void CallDog()
    {
       adultDogAgent.SetDestination(charController.transform.position);
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();

        if (handGrabInteractor.SelectedInteractable != null)
        {
            handEmptyR = 0;
            grabbedObjectR = handGrabInteractor.SelectedInteractable;
            // Debug.Log("Object? :" + grabbedObjectR.name);

            if (frameWithKey == 1)
            {

                if (grabbedObjectR.name == "rust_key1")
                {
                    block1.SetActive(false);
                    nextLocation = new Vector3(231.96636962890626f, 104.56011962890625f, 196.12344360351563f);
                }

                if (grabbedObjectR.name == "rust_key2")
                {
                    block2.SetActive(false);
                    nextLocation = new Vector3(178.3773651123047f, 101.2246322631836f, 162.6942901611328f);
                }

                if (grabbedObjectR.name == "rust_key3")
                {
                    block3.SetActive(false);
                    nextLocation = new Vector3(209.59800720214845f, 94.5009994506836f, 31.8700008392334f);
                }

                Invoke("DisappearKey", 2f);
            }
            frameWithKey++;

        }

        if (grabbedObjectR != null && handGrabInteractor.SelectedInteractable == null)
        {
            

            // Debug.Log("Object? :" + grabbedObjectR);
            if (handEmptyR == 0)
            {
            }
            ++handEmptyR;
        }
    }

    private void DisappearKey()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("harpChimes"));
        frameWithKey = 0;
        ParticleSystem ps = Instantiate(explosion, grabbedObjectR.transform.position, grabbedObjectR.transform.rotation);
        grabbedObjectR.gameObject.SetActive(false);
        //Destroy(ps, 5f);
    }
}

