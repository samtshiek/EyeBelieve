using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class StoryScript : MonoBehaviour
{
    GameObject dayTextObject;
    Text dayText;
    public int dayIncrement = 1;
    GameObject rawImageObject;
    RawImage rawImage;
    GameObject textobject2;
    GameObject ovrCameraRig;
    GameObject cineCamera;
    GameObject ebCutscene;
    GameObject vcamPlayer;
    public Text text2;
    bool fetch = false;
    bool feed = false;
    bool pet = false;
    bool inTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        dayTextObject = GameObject.Find("DayText");
        dayText = dayTextObject.GetComponent<Text>();
        rawImageObject = GameObject.Find("RawImage");
        rawImage = rawImageObject.GetComponent<RawImage>();
        //rawImageObject.SetActive(false);
        textobject2 = GameObject.Find("MyText2");
        text2 = (Text)textobject2.GetComponent("Text");
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        vcamPlayer = GameObject.Find("vcamPlayer");
        vcamPlayer.SetActive(false);
        cineCamera = GameObject.Find("CineCamera");
        cineCamera.SetActive(false);
        ebCutscene = GameObject.Find("EBCutscene");
        ebCutscene.SetActive(false);
        
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
            dayText.text = "Day " + dayIncrement;

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
        text2.text = "Fetched: " + fetch;
    }

    public void setFeed(bool fed)
    {
        feed = fed;
        text2.text = "Fed: " + feed;
    }

    public void setPet(bool petted)
    {
        pet = petted;
        text2.text = "Petted: " + pet;
    }

    public void switchToCutsceneCamera()
    {
        cineCamera.SetActive(true);
        vcamPlayer.SetActive(true);
        ebCutscene.SetActive(true);
        ovrCameraRig.SetActive(false);
    }

    public void custsceneDeactivate()
    {
        ovrCameraRig.SetActive(true);
        cineCamera.SetActive(false);
        vcamPlayer.SetActive(false);
        ebCutscene.SetActive(false);
    }

    public void changeOverlay()
    {
        if (dayIncrement == 2)
        {
            rawImageObject.SetActive(true);
            rawImage.material = Resources.Load<Material>("LHONmat2");
        }

        if (dayIncrement == 3)
        {
            rawImageObject.SetActive(true);
            rawImage.material = Resources.Load<Material>("LHONmat3");
        }
    }
}
