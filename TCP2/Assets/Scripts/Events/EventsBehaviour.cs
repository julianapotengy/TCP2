using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBehaviour : MonoBehaviour 
{
    GameObject frameObj;
    GameObject book;
    public bool rightRoom, leftFirstEvent;
    float quadroPosition, bookRotation, bookPosition;
    float randTime, randEvent, randBookRot;
    float leftCounter;
    public int leftRoom;

    public GameObject passosLeftRoom;
    public GameObject shadowLeftRoom;

    [HideInInspector] public bool tutorial;

    void Awake()
    {
        frameObj = GameObject.Find("Frame");
        book = GameObject.Find("Book");
        quadroPosition = frameObj.transform.position.y;
        bookPosition = book.transform.position.z;
        randTime = Random.Range(3, 11);
        randEvent = Random.Range(0, 2);
        randBookRot = Random.Range(45, 136);

        passosLeftRoom.SetActive(false);
        leftFirstEvent = true;
        leftRoom = 0;
    }

	void Start ()
    {
        Debug.Log(randTime + " evento: " + randEvent + " rotation " + randBookRot);
	}

    void FixedUpdate()
    {
        if (leftRoom > 0)
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

        if(leftCounter >= 5)
        {
            if(leftFirstEvent)
            {
                passosLeftRoom.SetActive(true);
                leftFirstEvent = false;
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

    public void ShadowGone()
    {
        passosLeftRoom.SetActive(false);
    }
}
