using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadGame()
    {
        
    }

    public void OpenGallery()
    {
        
    }

    public void OpenOptions()
    {

    }

    public void OpenCredits()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
