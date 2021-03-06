﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerController : MonoBehaviour
{
    [SerializeField] GameObject gameMngObj;
    GalleryManager galleryMng;
    GameManager gameMng;
    [SerializeField] GameObject pointer;
    PlayerBehaviour player;
    float anglePointer;
    bool canAdd;
    [SerializeField] Tutorial tutorial;
    [SerializeField] Image termometro;
    [SerializeField] Sprite[] termoImg;

    private void Start()
    {
        galleryMng = gameMngObj.GetComponent<GalleryManager>();
        gameMng = gameMngObj.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        anglePointer = 1;
        canAdd = true;
        pointer.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -50);
    }

    private void Update()
    {
        // com input
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            if (canAdd)
            {
                pointer.GetComponent<Transform>().Rotate(new Vector3(0, 0, anglePointer));
            }
            else if (!canAdd)
            {
                pointer.GetComponent<Transform>().Rotate(new Vector3(0, 0, -anglePointer));
            }

            if (pointer.GetComponent<Transform>().localRotation.z <= -0.45)
            {
                canAdd = true;
            }
            else if (pointer.GetComponent<Transform>().localRotation.z >= 0.45)
            {
                canAdd = false;
            }
        }*/

        if(pointer.GetComponent<Transform>().localRotation.z <= 0.45)
        {
            termometro.sprite = termoImg[0];
        }
        else termometro.sprite = termoImg[1];

        if ((player.room1Time >= 5 && !Input.GetKey(KeyCode.A)) || tutorial.bustoCollide)
        {
            pointer.GetComponent<AudioSource>().enabled = true;
            if (pointer.GetComponent<Transform>().localRotation.z <= 0.45)
                pointer.GetComponent<Transform>().Rotate(new Vector3(0, 0, anglePointer));
        }

        if(!tutorial.bustoCollide && player.room1Time < 5)
        {
            termometro.sprite = termoImg[0];
        }
    }
}
