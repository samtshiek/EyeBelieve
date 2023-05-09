using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


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
    GameObject pee;

    AccessibleUIGroupRoot accessibleUIGroupRoot;
    AccessibleTextEdit accessibleTextEdit;
    
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Puppy_Labrador_IP");
        dogAgent = dog.GetComponent<NavMeshAgent>();
        canvasObject = GameObject.Find("Canvas");
        oVRCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        charController = GetComponent<CharacterController>();
        textobject = GameObject.Find("MyText");
        text = (Text)textobject.GetComponent("Text");
        textobject2 = GameObject.Find("MyText2");
        text2 = (Text)textobject2.GetComponent("Text");
        rawImageObject = GameObject.Find("RawImage");
        rawImage = rawImageObject.GetComponent<RawImage>();
        pee = GameObject.Find("Pee");
        pee.GetComponent<Renderer>().enabled = false;

        accessibleUIGroupRoot = canvasObject.GetComponent<AccessibleUIGroupRoot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        
        //text.text = "EyeA: " + centerEyeAnchor.transform.localPosition;
        //text2.text = "Char: " + charController.transform.position;


        //Button A pressed
        if (OVRInput.Get(OVRInput.Button.One))
        {
            //text.text = "'A' button.";
            //accessibleTextEdit.enabled = true;
            //accessibleTextEdit = textobject2.GetComponent<AccessibleTextEdit>();
            //accessibleTextEdit.SetCustomText("Come on, work now!");
            //rawImage.material.mainTexture = Resources.Load<Texture>("kof");
            rawImageObject.SetActive(true);
            if (accessibleTextEdit == null)
            {
                UAP_AccessibilityManager.EnableAccessibility(true);
                
                text.text = "Is enabled?: " + UAP_AccessibilityManager.IsEnabled();
                text2.text = "Is Active?: " + UAP_AccessibilityManager.IsActive();
                audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
            }
            else
            {
                text.text = "TextAcc: " + UAP_AccessibilityManager.IsActive();
                accessibleTextEdit.SelectItem(true);
                audioSource.PlayOneShot(accessibleTextEdit.GetCurrentValueAsAudio());
            }

            

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
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / 50, (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / 50));
            
        }


        //Right Thumbstick pushed down
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            charController.Move(new Vector3(centerEyeAnchor.transform.forward.x / (-50), (-gravity * Time.deltaTime), centerEyeAnchor.transform.forward.z / (-50)));
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

            UAP_AccessibilityManager.Say("Hello there.");

            
            //AccessibleUIGroupRoot.Accessible_UIElement element
            
        }

        //Right hand trigger pushed
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.0)
        {
            text.text = "Dog Moving: " + dogAgent.transform.position;
            dogAgent.SetDestination(charController.transform.position);
        }

        if(Input.GetKeyDown(KeyCode.Equals))
        {
            UAP_AccessibilityManager.EnableAccessibility(true);
            Debug.Log("UAP ENABLED? :" + UAP_AccessibilityManager.IsEnabled());
            Debug.Log("UAP ACTIVE? :" + UAP_AccessibilityManager.IsActive());

            UAP_AccessibilityManager.Say("Hello there.");
        }

        

    }

  /*  private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        
    }*/


}
