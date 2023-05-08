using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryScript : MonoBehaviour
{
    GameObject dayTextObject;
    Text dayText;
    int dayIncrement = 0;
    // Start is called before the first frame update
    void Start()
    {
        dayTextObject = GameObject.Find("DayText");
        dayText = dayTextObject.GetComponent<Text>();
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
        }
    }
}
