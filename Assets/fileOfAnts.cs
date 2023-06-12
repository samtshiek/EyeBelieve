using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileOfAnts : MonoBehaviour
{
    GameObject dog;
    public AudioSource dogAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Labrador");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Labrador")
        {
            dogAudioSource.PlayOneShot(Resources.Load<AudioClip>("AI dog/A file of ants"));
        }
    }
}
