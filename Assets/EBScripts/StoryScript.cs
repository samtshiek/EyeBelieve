using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class StoryScript : MonoBehaviour
{
    //GameObject dayTextObject;
  //  Text dayText;
    public bool meetFriend = true;
    public int dayIncrement = 1;
    GameObject rawImageObject;
    RawImage rawImage;
  //  GameObject textobject2;
    GameObject ovrCameraRig;
    GameObject cineCamera;
    GameObject sleepWakeCutscene;
    GameObject outOfBedCutscene;
    GameObject vcamPlayer;
    GameObject ovrInteraction;
    GameObject pee;
  //  public Text text2;
    bool fetch = false;
    bool feed = false;
    bool pet = false;
    bool inTrigger = false;
    GameObject dog;
    NavMeshAgent dogAgent;
    NavMeshAgent adultDogAgent;
    GameObject adultDog;
    Animator adultDogAnimator;
    PlayerController playerController;
    FeedController feedController;
    GameObject canvasObject;
    // GameObject externalDog;


    // Start is called before the first frame update
    void Start()
    {
       
       // dayTextObject = GameObject.Find("DayText");
       // dayText = dayTextObject.GetComponent<Text>();
        rawImageObject = GameObject.Find("RawImage");
        rawImage = rawImageObject.GetComponent<RawImage>();
        rawImageObject.SetActive(false);
      //  textobject2 = GameObject.Find("MyText2");
      //  text2 = (Text)textobject2.GetComponent("Text");
        vcamPlayer = GameObject.Find("vcamPlayer");
        //vcamPlayer.SetActive(false);
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        ovrCameraRig.SetActive(false);
        cineCamera = GameObject.Find("CineCamera");
        //cineCamera.SetActive(false);
        sleepWakeCutscene = GameObject.Find("SleepWakeCutscene");
        sleepWakeCutscene.SetActive(false);
        outOfBedCutscene = GameObject.Find("OutOfBedCutscene");
        pee = GameObject.Find("DogPee");
        dog = GameObject.Find("Puppy_Labrador_IP");
        playerController = ovrCameraRig.GetComponent<PlayerController>();
        dogAgent = dog.GetComponent<NavMeshAgent>();
        adultDog = GameObject.Find("Labrador_Adult");
        adultDog.SetActive(false);
        adultDogAgent = adultDog.GetComponent<NavMeshAgent>();
        adultDogAnimator = adultDog.GetComponent<Animator>();
        feedController = GameObject.Find("dog_food_02").GetComponent<FeedController>();
        canvasObject = GameObject.Find("Canvas");
        canvasObject.SetActive(false);

        // externalDog = dog;
        // playerController = externalDog.GetComponent<PlayerController>();
        //
        //externalDog = playerController.GetComponent<PlayerController>().dog;

        // adultDog.SetActive(false);
        // adultDog.GetComponent<Renderer>().enabled = false;
        //outOfBedCutscene.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRCameraRig" && !inTrigger /*&& activitiesComplete()*/)
        {
            inTrigger = true;
            ++dayIncrement;
            fetch = false;
            feed = false;
            pet = false;
           // dayText.text = "Day " + dayIncrement;

            switchToCutsceneCamera();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    public bool activitiesComplete()
    {
        if (feed == true && fetch == true && pet == true)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void setFetch(bool fetched)
    {
        fetch = fetched;
       // text2.text = "Fetched: " + fetch;
    }

    public bool getFetch()
    {
        return fetch;
    }

    public void setFeed(bool fed)
    {
        feed = fed;
       // text2.text = "Fed: " + feed;
    }

    public bool getFeed()
    {
        return feed;
    }

    public void setPet(bool petted)
    {
        pet = petted;
       // text2.text = "Petted: " + pet;
    }

    public bool getPet()
    {
        return pet;
    }

    public void switchToCutsceneCamera()
    {
        cineCamera.SetActive(true);
        vcamPlayer.SetActive(true);
        outOfBedCutscene.SetActive(false);
        sleepWakeCutscene.SetActive(true);
        ovrCameraRig.SetActive(false);
    }

    public void custsceneDeactivate()
    {
        ovrCameraRig.SetActive(true);
        cineCamera.SetActive(false);
        vcamPlayer.SetActive(false);
        sleepWakeCutscene.SetActive(false);
        outOfBedCutscene.SetActive(false);
        Debug.Log("CUTSCENE DEACTIVATE CALLED");
    }

    public void activateOVRCam()
    {
        ovrCameraRig.SetActive(true);
    }

    public void changeOverlay()
    {
        if (dayIncrement == 2)
        {
            canvasObject.SetActive(true);
            rawImageObject.SetActive(true);
            rawImage.material = Resources.Load<Material>("LHONmat1");
            pee.GetComponent<Renderer>().enabled = false;

            

        }

        if (dayIncrement == 3)
        {
           
            //  adultDog.transform.position = dog.transform.position;
            // dog.SetActive(false);

            //  dog = adultDog;
            // adultDog.GetComponent<Renderer>().enabled = true ;
            // dogAgent = dog.GetComponent<NavMeshAgent>();

            //  dog.SetActive(true);
            //CHANGE DOGS

            dog.SetActive(false);
            adultDog.SetActive(true);
            dogAgent = adultDogAgent;
            playerController.dogAgent = adultDogAgent;
            feedController.dogAgent = adultDogAgent;
            dog = adultDog;
            playerController.dog = adultDog;
            feedController.dog = adultDog;
            feedController.dogAnimator = adultDogAnimator;
            dog.SetActive(true);
            canvasObject.SetActive(true);
            rawImage.material = Resources.Load<Material>("LHONmat2");
            rawImageObject.SetActive(true);
        }
    }
}
