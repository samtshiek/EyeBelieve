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
    // Start is called before the first frame update
    void Start()
    {
        dayTextObject = GameObject.Find("DayText");
        dayText = dayTextObject.GetComponent<Text>();
        rawImageObject = GameObject.Find("RawImage");
        rawImage = rawImageObject.GetComponent<RawImage>();
        rawImageObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRCameraRig")
        {
            ++dayIncrement;
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
}
