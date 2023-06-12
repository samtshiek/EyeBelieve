using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeyNearby1 : MonoBehaviour
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
            dogAudioSource.PlayOneShot(Resources.Load<AudioClip>("AI dog/Key nearby"));
            //hikePlayerController.nextLocation = new Vector3(231.96636962890626f, 104.56011962890625f, 196.12344360351563f);
        }
    }
    
}
