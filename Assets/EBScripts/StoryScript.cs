using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryScript : MonoBehaviour
{
    GameObject dayTextObject;
    Text dayText;
    int dayIncrement = 1;
    GameObject rawImageObject;
    RawImage rawImage;
    GameObject textobject2;
    Text text2;
    bool fetch = false;
    bool feed = false;
    bool pet = false;

    // Start is called before the first frame update
    void Start()
    {
        dayTextObject = GameObject.Find("DayText");
        dayText = dayTextObject.GetComponent<Text>();
        rawImageObject = GameObject.Find("RawImage");
        rawImage = rawImageObject.GetComponent<RawImage>();
        rawImageObject.SetActive(false);
        textobject2 = GameObject.Find("MyText2");
        text2 = (Text)textobject2.GetComponent("Text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRCameraRig" && activitiesComplete())
        {
            ++dayIncrement;
            fetch = false;
            feed = false;
            pet = false;
            dayText.text = "Day " + dayIncrement;

            if (dayIncrement == 2)
            {
                rawImageObject.SetActive(true);
                rawImage.material.mainTexture = Resources.Load<Texture>("LHON");
            }

            if (dayIncrement == 3)
            {
                rawImageObject.SetActive(true);
                rawImage.material.mainTexture = Resources.Load<Texture>("LHON2");
            }
        }
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
}
