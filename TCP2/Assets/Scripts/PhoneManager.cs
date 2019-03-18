using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    [Header("Objeto do jogador")]
    public GameObject player;
    [Header("Objeto da tela desbloqueada")]
    public GameObject unlockedInter;
    [Header("Objeto da tela bloqueada")]
    public GameObject lockedInter;
    [Header("Objeto da tela de menu")]
    public GameObject menuInter;
    [Header("Objeto da interface do celular")]
    public GameObject gameInter;
    [Header("Objeto da interface da galeria")]
    public GameObject galleryInter;
    [Header("Objeto da interface da imagem")]
    public GameObject image1Inter;

    private bool locked, inGallery, inImage, big;
    [HideInInspector] public bool phoneMode, inMenu;

    private void Start()
    {
        phoneMode = false;
        inGallery = true;
        inMenu = false;
        inImage = true;
        big = false;
        unlockedInter.SetActive(false);
        locked = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !inMenu)
        {
            locked = !locked;
            big = !big;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inMenu = !inMenu;
            if (!big)
                big = true;
            else if (big && locked)
                big = false;
            else if (big && !locked)
                big = true;
        }

        Conditions();
    }

    public void Conditions()
    {
        if (locked)
        {
            unlockedInter.SetActive(false);
            lockedInter.SetActive(true);
            phoneMode = false;
            inGallery = false;
            inImage = false;
        }
        else if (!locked)
        {
            unlockedInter.SetActive(true);
            lockedInter.SetActive(false);
            phoneMode = true;
        }

        if (inGallery)
        {
            gameInter.SetActive(false);
            galleryInter.SetActive(true);
            if (inImage)
            {
                image1Inter.SetActive(true);
            }
            else if (!inImage)
            {
                image1Inter.SetActive(false);
            }
        }
        else if (!inGallery)
        {
            gameInter.SetActive(true);
            galleryInter.SetActive(false);
        }

        if (inMenu)
        {
            Time.timeScale = 0;
            phoneMode = true;
            menuInter.SetActive(true);
        }
        else if (!inMenu)
        {
            Time.timeScale = 1;
            menuInter.SetActive(false);
        }

        if(big)
        {
            this.gameObject.transform.localPosition = new Vector3(-0.95f, 0.52f, 2f);
            this.gameObject.transform.localScale = new Vector3(0.14f, 2.2f * 2, 1.15f * 2);
        }
        else if(!big)
        {
            this.gameObject.transform.localPosition = new Vector3(-0.95f, 0.52f, 0f);
            this.gameObject.transform.localScale = new Vector3(0.14f, 2.2f, 1.15f);
        }
    }

    public void GalleryButton()
    {
        inGallery = !inGallery;
    }

    public void Image1()
    {
        inImage = !inImage;
    }
}
