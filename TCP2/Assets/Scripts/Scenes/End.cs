using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public void PassImage(GameObject next)
    {
        next.SetActive(true);
    }

    public void Menu(string name)
    {
        SceneManager.LoadScene(name);
    }
}
