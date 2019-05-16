using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBehaviour : MonoBehaviour 
{
    GameObject frameObj;
    GameObject book;
    bool leftRoom;
    float quadroPosition, bookRotation, bookPosition;
    float randTime, randEvent, randBookRot;
    float leftCounter;

    void Awake()
    {
        frameObj = GameObject.Find("Frame");
        book = GameObject.Find("Book");
        quadroPosition = frameObj.transform.position.y;
        bookPosition = book.transform.position.z;
        randTime = Random.Range(3, 11);
        randEvent = Random.Range(0, 2);
        randBookRot = Random.Range(45, 136);
    }

	void Start ()
    {
        leftRoom = true;
        Debug.Log(randTime + " evento: " + randEvent + " rotation " + randBookRot);
	}

    void FixedUpdate()
    {
        if (leftRoom)
        {
            LeftRoomEvent();
        }
    }

    void LeftRoomEvent()
    {
        leftCounter += Time.deltaTime;
        if(leftCounter >= randTime)
        {
            if (randEvent == 0)
                FrameFalling();
            else if(randEvent == 1)
            {
                BookFalling();
            }
        }
    }

    void FrameFalling()
    {
        if (frameObj.transform.position.y >= 0.6f)
        {
            quadroPosition -= 0.05f;
            frameObj.transform.position = new Vector3(frameObj.transform.position.x, quadroPosition, frameObj.transform.position.z);
        }
    }

    void BookFalling()
    {
        book.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 100, ForceMode.Acceleration);
            //book.GetComponent<Rigidbody>().AddTorque(transform.right * 45);
    }
}
