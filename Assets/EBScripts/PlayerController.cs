using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Oculus.Interaction.HandGrab;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    GameObject dog;
    NavMeshAgent dogAgent;
    GameObject canvasObject;
    GameObject oVRCameraRig;
    GameObject centerEyeAnchor;
    CharacterController charController;
    GameObject textobject;
    Text text;
    GameObject textobject2;
    Text text2;
    float gravity = 9.8f;
    public AudioSource audioSource;
    GameObject rawImageObject;
    RawImage rawImage;
  //  GameObject pee;
   // GameObject dogPee;
    float shapeWeight = 0;
    GameObject bedObject;
    StoryScript storyScript;
    GameObject handGrab;
    HandGrabInteractor handGrabInteractor;
    HandGrabInteractable grabbedObjectR = null;
    bool shouldFetch = false;
    bool returnToThrower_b = false;
    bool startedNavigating = false;
    int handEmptyR = 0;
    int overlayCount = 0;
    

    AccessibleUIGroupRoot accessibleUIGroupRoot;
    AccessibleTextEdit accessibleTextEdit;
    
    // Start is called before the first frame update
    void Start()
    {
        bedObject = GameObject.Find("PFB_Bed");
        storyScript = bedObject.GetComponent<StoryScript>();
        handGrab = GameObject.Find("HandGrabInteractorR");
        handGrabInteractor = handGrab.GetComponent<HandGrabInteractor>();
        dog = GameObject.Find("Puppy_Labrador_IP");
        dogAgent = dog.GetComponent<NavMeshAgent>();
        canvasObject = GameObject.Find("Canvas");
        oVRCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        charController = GetComponent<CharacterController>();
        textobject = GameObject.Find("MyText");
        text = (Text)textobject.GetComponent("Text");
        textobject2 = GameObject.Find("MyText2");
        accessibleTextEdit = textobject2.GetComponent<AccessibleTextEdit>();
        text2 = (Text)textobject2.GetComponent("Text");
        rawImageObject = GameObject.Find("RawImage");
        rawImage = rawImageObject.GetComponent<RawImage>();
        //rawImageObject.SetActive(false);
       //  pee = GameObject.Find("DogPee");
       //  pee.GetComponent<Renderer>().enabled = false;

        accessibleUIGroupRoot = canvasObject.GetComponent<AccessibleUIGroupRoot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        
       // text.text = "Dist: " + Vector3.Distance(centerEyeAnchor.transform.position, dog.transform.position);
        //text2.text = "Hand: " + OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);



        //Button A pressed
        if (OVRInput.Get(OVRInput.Button.One))
        {
            //text.text = "'A' button.";
            accessibleTextEdit.enabled = true;
            accessibleTextEdit = textobject2.GetComponent<AccessibleTextEdit>();
            accessibleTextEdit.SetCustomText("Come on, work now!");
            //rawImage.material.mainTexture = Resources.Load<Texture>("LHON2Recent");
            //rawImageObject.SetActive(true);
            //rawImage.material= Resources.Load<Material>("LHONmat");
            //rawImageObject.SetActive(true);
            switch (overlayCount)
            {
                case 1:
                    rawImage.material = Resources.Load<Material>("LHONmat");
                    rawImageObject.SetActive(true);
                    break;

                case 2:
                    rawImage.material = Resources.Load<Material>("LHONmat2");
                    rawImageObject.SetActive(true);
                    overlayCount = 0;
                    break;
            }

            rawImageObject.SetActive(true);
            //rawImage.material = Resources.Load<Material>("KofMat");
            //rawImage.material.mainTexture = Resources.Load<Texture>("kof");
            audioSource.PlayOneShot(accessibleTextEdit.m_TextAsAudio);
            if (accessibleTextEdit == null)
            {
                UAP_AccessibilityManager.EnableAccessibility(true);
                
                text.text = "Is enabled?: " + UAP_AccessibilityManager.IsEnabled();
                text2.text = "Is Active?: " + UAP_AccessibilityManager.IsActive();

                UAP_AccessibilityManager.Say("Welcome back?");
                
                //audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            }

            else
            {
                UAP_AccessibilityManager.EnableAccessibility(true);

                text.text = "Is enabled?: " + UAP_AccessibilityManager.IsEnabled();
                text2.text = "Is Active?: " + UAP_AccessibilityManager.IsActive();
                //accessibleTextEdit.SelectItem(true);
                
                
                //UAP_AccessibilityManager.Say("Welcome back?");
                audioSource.PlayOneShot(accessibleTextEdit.m_TextAsAudio);
            }


            ++overlayCount;
        }

        //Button X pressed
        //if (OVRInput.Get(OVRInput.Button.Three))
        //{
        //    text.text = "'X' button.";
        //    dogPee = GameObject.Find("DogPee");
        //}

        //if (dogPee != null)
        //{
        //    SkinnedMeshRenderer skinnedMeshRenderer = dogPee.GetComponent<SkinnedMeshRenderer>();
        //    if (shapeWeight < 100.0)
        //    {
        //        shapeWeight += 1f;
        //        text.text = "shapeWight: " + shapeWeight;
        //        skinnedMeshRenderer.SetBlendShapeWeight(0, shapeWeight);
        //    }
        //}

        //Button Y pressed
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            text.text = "'Y' button.";
        }



        //Button B pressed
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            text.text = "'B' button.";
            rawImageObject.SetActive(false);
        }

        //Right Thumbstick pushed up
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / 30, (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / 50));
            
        }


        //Right Thumbstick pushed down
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / (-30), (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / (-50)));
        }


        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            text.text = "P Thumbstick UP' button.";
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            text.text = "P Thumbstick DOWN' button.";
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0)
        {
            UAP_AccessibilityManager.EnableAccessibility(true);

            //UAP_AccessibilityManager.Say("Hello there.");

            
            //AccessibleUIGroupRoot.Accessible_UIElement element
            
        }

        //Right hand trigger pushed
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.0)
        {
            text.text = "Dog Moving: " + dogAgent.transform.position;
            dogAgent.SetDestination(charController.transform.position);
        }

        //Left hand trigger pushed
        /*if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0)
        {
            GameObject dogInteractObject = GameObject.Find("Stick");
            text.text = "Dog Moving to Stick";
            dogAgent.SetDestination(dogInteractObject.transform.position);
        }*/

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            UAP_AccessibilityManager.EnableAccessibility(true);
            Debug.Log("UAP ENABLED? :" + UAP_AccessibilityManager.IsEnabled());
            Debug.Log("UAP ACTIVE? :" + UAP_AccessibilityManager.IsActive());

            UAP_AccessibilityManager.Say("Hello there.");
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();

        if (handGrabInteractor.SelectedInteractable != null)
        {
            handEmptyR = 0;
            grabbedObjectR = handGrabInteractor.SelectedInteractable;
        }
        
        if (grabbedObjectR != null && handGrabInteractor.SelectedInteractable == null)
        {
            if(handEmptyR == 0)
            {
                shouldFetch = true;
            }
            ++handEmptyR;
        }

        //Dog fetches thrown object
        
        dogFetch();
        //Dog returns object to thrower
        returnToThrower();
    }

    void dogFetch()
    {
        if (shouldFetch)
        {

            if (Vector3.Distance(dog.transform.position, grabbedObjectR.transform.position) < 0.7f && startedNavigating)
            {
                shouldFetch = false;
                startedNavigating = false;
                GameObject tongue = GameObject.Find("tongue_3");
                grabbedObjectR.Rigidbody.isKinematic = true;
                grabbedObjectR.GetComponent<BoxCollider>().enabled = false;
                grabbedObjectR.transform.position = tongue.transform.position;
                grabbedObjectR.transform.SetParent(tongue.transform);
                returnToThrower_b = true;
            }
            else
            {
                if (handEmptyR == 1)
                {
                    Invoke("goToThrownObject", 0.5f);
                }
            }
        }
    }

    public void goToThrownObject()
    {
        dogAgent.SetDestination(grabbedObjectR.transform.position);
        dogAgent.stoppingDistance = 0.0f;
        startedNavigating = true;
    }

    public void returnToThrower()
    {
        if(returnToThrower_b)
        {
            if (Vector3.Distance(charController.transform.position, dog.transform.position) < 0.7f && startedNavigating)
            {
                returnToThrower_b = false;
                startedNavigating = false;
                grabbedObjectR.transform.SetParent(null);
                grabbedObjectR.GetComponent<BoxCollider>().enabled = true;
                grabbedObjectR.Rigidbody.isKinematic = false;
                storyScript.setFetch(true);
            }
            else
            {
                dogAgent.SetDestination(charController.transform.position);
                dogAgent.stoppingDistance = 0.3f;
                startedNavigating = true;
            }
        }
    }
}
