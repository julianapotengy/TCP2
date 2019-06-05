using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject gallery;
    [SerializeField] GameObject options;
    [SerializeField] GameObject credits;

    void Start()
    {
        gallery.SetActive(false);
        options.SetActive(false);
    }

    public void NewGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadGame()
    {
        
    }

    public void OpenGallery()
    {
        if(!gallery.activeSelf)
        {
            gallery.SetActive(true);
            options.SetActive(false);
        }
    }

    public void OpenOptions()
    {
        if (!options.activeSelf)
        {
            gallery.SetActive(false);
            options.SetActive(true);
        }
    }

    public void OpenCredits()
    {
        if (!credits.activeSelf)
        {
            
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
