using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    [SerializeField] GameObject gameMngObj;
    GalleryManager galleryMng;
    GameManager gameMng;
    [SerializeField] GameObject pointer;
    float anglePointer;
    bool canAdd;

    private void Start()
    {
        galleryMng = gameMngObj.GetComponent<GalleryManager>();
        gameMng = gameMngObj.GetComponent<GameManager>();
        anglePointer = 1;
        canAdd = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (canAdd)
            {
                pointer.GetComponent<Transform>().Rotate(new Vector3(0, 0, anglePointer));
            }
            else if (!canAdd)
            {
                pointer.GetComponent<Transform>().Rotate(new Vector3(0, 0, -anglePointer));
            }
        }

        if (pointer.GetComponent<Transform>().localRotation.z <= -0.45)
        {
            canAdd = true;
        }
        else if (pointer.GetComponent<Transform>().localRotation.z >= 0.45)
        {
            canAdd = false;
        }
    }
}
