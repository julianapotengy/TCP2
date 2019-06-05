using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGallery : MonoBehaviour
{
    [SerializeField] GameObject[] images;

    void Start()
    {
        images[0].SetActive(false);
        images[1].SetActive(false);
        images[2].SetActive(false);
    }
	
	void Update ()
    {
		if(PlayerPrefs.GetInt("Unlocked 0", 1) == 1)
        {
            images[0].SetActive(true);
        }
        else if(PlayerPrefs.GetInt("Unlocked 1") == 1)
        {
            images[1].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Unlocked 2") == 1)
        {
            images[2].SetActive(true);
        }
    }
}
