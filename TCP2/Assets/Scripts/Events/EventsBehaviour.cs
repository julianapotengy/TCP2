using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] AudioSource bookAudioSrc;
    [SerializeField] AudioSource frameAudioSrc;
    [SerializeField] AudioClip dropSound;

    [HideInInspector] public bool tutorial;

    [SerializeField] Text subtitle;
    float picCounter;
    public bool canPic, tookPic, colPlayer, canIncreaseInsanity1, canIncreaseInsanity2;

    public GameManager gameMng;

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
        canPic = false;
        tookPic = false;
        colPlayer = false;
        canIncreaseInsanity1 = true;
        canIncreaseInsanity2 = true;
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

        if(canPic)
        {
            picCounter += Time.deltaTime;

            if(picCounter >= 3)
            {
                subtitle.text = "";
                picCounter = 0;
                canPic = false;
            }
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

            if (canIncreaseInsanity1)
            {
                gameMng.insanity += 25;
                canIncreaseInsanity1 = false;
            }
        }

        if(leftCounter >= 5)
        {
            if(leftFirstEvent)
            {
                passosLeftRoom.SetActive(true);
                if (canIncreaseInsanity2)
                {
                    gameMng.insanity += 25;
                    canIncreaseInsanity2 = false;
                }
                leftFirstEvent = false;
            }
        }
    }

    void FrameFalling()
    {
        if (frameObj.transform.position.y >= 0.7f)
        {
            quadroPosition -= 0.05f;
            frameObj.transform.position = new Vector3(frameObj.transform.position.x, quadroPosition, frameObj.transform.position.z);
        }
        else frameAudioSrc.PlayOneShot(dropSound);
    }

    void BookFalling()
    {
        book.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Acceleration);
        bookAudioSrc.PlayOneShot(dropSound);
    }

    public void ShadowGone()
    {
        passosLeftRoom.SetActive(false);
    }

    public void RightPic()
    {
        if(!tookPic && colPlayer)
        {
            subtitle.text = "Isso daria uma boa foto.";
            canPic = true;
        }
    }
}