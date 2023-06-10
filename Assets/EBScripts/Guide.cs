using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    StoryScript storyScript;
    GameObject bedObject;
    GameObject friend;
    AudioSource audioSource;
    GameObject outroCutscene;

    // Start is called before the first frame update
    void Start()
    {
        bedObject = GameObject.Find("PFB_Bed");
        friend = GameObject.Find("Friend");
        audioSource = friend.GetComponent<AudioSource>();
        storyScript = bedObject.GetComponent<StoryScript>();
        outroCutscene = GameObject.Find("OutroCutscene");
        outroCutscene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OVRCameraRig")
        {
            Debug.Log("Entering GUIDE!!!");
            if (!storyScript.getFetch())
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Sam Recs/Play Fetch"));
            }

            else if (!storyScript.getFeed())
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Sam Recs/Try Feeding"));
            }

            else if (!storyScript.getPet())
            {
                audioSource.PlayOneShot(Resources.Load<AudioClip>("Sam Recs/Petting Time"));
            }

            else if (storyScript.dayIncrement == 3)
            {
                outroCutscene.SetActive(true);
            }
        }
    }
}
