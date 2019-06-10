using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private Image[] img;
    [SerializeField] private Image[] bigImg;

    [SerializeField] private Sprite[] friendImages;
    [SerializeField] private Sprite[] bustoImages;
    [SerializeField] private Sprite[] professorImages;

    GameManager gameMng;
    
   private void Start()
    {
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        bigImg[0].sprite = img[0].sprite;
        bigImg[1].sprite = img[1].sprite;
        bigImg[2].sprite = img[2].sprite;
        bigImg[3].sprite = img[3].sprite;

        if(gameMng.insanity <= 0)
        {
            img[1].sprite = friendImages[0];
            img[2].sprite = bustoImages[0];
            img[3].sprite = professorImages[0];
        }
        else if(gameMng.insanity >= 25 && gameMng.insanity < 50)
        {
            img[1].sprite = friendImages[1];
            img[2].sprite = bustoImages[0];
            img[3].sprite = professorImages[0];
        }
        else if (gameMng.insanity >= 50 && gameMng.insanity < 75)
        {
            img[1].sprite = friendImages[2];
            img[2].sprite = bustoImages[1];
            img[3].sprite = professorImages[0];
        }
        else if (gameMng.insanity >= 75 && gameMng.insanity < 100)
        {
            img[1].sprite = friendImages[3];
            img[2].sprite = bustoImages[2];
            img[3].sprite = professorImages[1];
        }
        else if (gameMng.insanity >= 100)
        {
            img[1].sprite = friendImages[4];
            img[2].sprite = bustoImages[2];
            img[3].sprite = professorImages[1];
        }
    }
}
