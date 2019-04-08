﻿using System.Collections;
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
    public GameObject[] imageInter;
    [Header("Objeto da interface do radar")]
    public GameObject radarInter;

    private bool locked, inGallery, inImage, big, inRadar;
    [HideInInspector] public bool phoneMode, inMenu;
    string imgLastClick;
    private float normalSpeed, lowerSpeed;

    private void Start()
    {
        phoneMode = false;
        inGallery = true;
        inMenu = false;
        inImage = true;
        big = false;
        inRadar = false;
        unlockedInter.SetActive(false);
        locked = true;
        normalSpeed = 5;
        lowerSpeed = normalSpeed / 3;
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
            player.GetComponent<PlayerBehaviour>().speed = normalSpeed;
            phoneMode = false;
            inGallery = false;
            inImage = false;
            inRadar = false;
        }
        else if (!locked)
        {
            unlockedInter.SetActive(true);
            lockedInter.SetActive(false);
            player.GetComponent<PlayerBehaviour>().speed = lowerSpeed;
            phoneMode = true;
        }

        if (inGallery)
        {
            gameInter.SetActive(false);
            galleryInter.SetActive(true);
            if (inImage)
            {
                if(imgLastClick == "Image0")
                {
                    imageInter[0].SetActive(true);
                }
                if(imgLastClick == "Image1")
                {
                    imageInter[1].SetActive(true);
                }
            }
            else if (!inImage)
            {
                if (imgLastClick == "Image0BIG")
                {
                    imageInter[0].SetActive(false);
                }
                if (imgLastClick == "Image1BIG")
                {
                    imageInter[1].SetActive(false);
                }
            }
        }
        else if (!inGallery)
        {
            if (imgLastClick == "Image0BIG")
            {
                imageInter[0].SetActive(false);
            }
            if (imgLastClick == "Image1BIG")
            {
                imageInter[1].SetActive(false);
            }
            gameInter.SetActive(true);
            galleryInter.SetActive(false);
        }

        if(inRadar)
        {
            gameInter.SetActive(false);
            radarInter.SetActive(true);
        }
        else if(!inRadar)
        {
            gameInter.SetActive(true);
            radarInter.SetActive(false);
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
            this.gameObject.transform.localPosition = new Vector3(-1.1f, 0.52f, 2f);
            this.gameObject.transform.localScale = new Vector3(0.14f * 2, 2.2f * 2, 1.15f * 2);
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

    public void Image(Button button)
    {
        inImage = !inImage;
        imgLastClick = button.name;
    }

    public void RadarButton()
    {
        inRadar = !inRadar;
    }
}
