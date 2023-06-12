using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EasyOne : MonoBehaviour
{
    GameObject dog;
    NavMeshAgent dogAgent;
    public AudioSource dogAudioSource;
    GameObject ovrCamera;
    HikePlayerController hikePlayerController;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Labrador");
        dogAgent = dog.GetComponent<NavMeshAgent>();
        ovrCamera = GameObject.Find("OVRCameraRig");
        hikePlayerController = ovrCamera.GetComponent<HikePlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Labrador")
        {
            dogAudioSource.PlayOneShot(Resources.Load<AudioClip>("AI dog/Seems an easy one"));
            hikePlayerController.nextLocation = new Vector3(205.77699279785157f, 95.4260025024414f, 32.41699981689453f);
        }
    }
}
