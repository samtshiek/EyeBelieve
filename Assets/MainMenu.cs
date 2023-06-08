using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public void StartLhon ()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene("EBExperience");
    }

    public void StartHike()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("harpChimes"));
        SceneManager.LoadScene(2);
        //SceneManager.LoadScene("EBHike");
    }

    public void Quit ()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("dogBark"));
        Application.Quit();         
    }
}
