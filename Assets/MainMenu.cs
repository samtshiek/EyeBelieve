using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartLhon ()
    {
        SceneManager.LoadScene(1);
    }

    public void StartHike()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit ()
    {
        Application.Quit();         
    }
}
