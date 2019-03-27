using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private Image[] img;
    [SerializeField] private Image[] bigImg;
    bool trigger1;

    [SerializeField] private Sprite[] friendImages;

    GameManager gameMng;
    
   private void Start()
    {
        trigger1 = false;
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        bigImg[1].sprite = img[1].sprite;

        if (Input.GetKeyDown(KeyCode.Space) && !trigger1)
        {
            trigger1 = true;
        }
        
        if (trigger1)
        {
            img[1].gameObject.SetActive(true);
        }
        else if (!trigger1)
        {
            img[1].gameObject.SetActive(false);
        }

        if(gameMng.insanity <= 0)
        {
            img[1].sprite = friendImages[0];
        }
        else if(gameMng.insanity >= 25 && gameMng.insanity < 50)
        {
            img[1].sprite = friendImages[1];
        }
        else if (gameMng.insanity >= 50 && gameMng.insanity < 75)
        {
            img[1].sprite = friendImages[2];
        }
        else if (gameMng.insanity >= 75 && gameMng.insanity < 100)
        {
            img[1].sprite = friendImages[3];
        }
        else if (gameMng.insanity >= 100)
        {
            img[1].sprite = friendImages[4];
        }
    }
}
