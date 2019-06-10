using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGallery : MonoBehaviour
{
    [SerializeField] GameObject[] images;

    void Start()
    {
        if (PlayerPrefs.GetInt("Unlocked 0", 1) == 0)
        {
            images[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Unlocked 1") == 0)
        {
            images[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Unlocked 2") == 0)
        {
            images[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("Unlocked 3") == 0)
        {
            images[3].SetActive(false);
        }
    }
	
	void Update ()
    {
		if(PlayerPrefs.GetInt("Unlocked 0", 1) == 1)
        {
            images[0].SetActive(true);
        }
        if(PlayerPrefs.GetInt("Unlocked 1") == 1)
        {
            images[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Unlocked 2") == 1)
        {
            images[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Unlocked 3") == 1)
        {
            images[3].SetActive(true);
        }
    }
}
