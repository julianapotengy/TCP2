using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    float gLightInt, lastInt;
    Color blueColor, redColor;
    
    [SerializeField] private PhoneManager phoneMgn;
    [SerializeField] private PlayerBehaviour player;
    public float insanity;
    [HideInInspector] public bool firstBox;
    [SerializeField] private GameObject fogParticle;

    [HideInInspector] public float insanityTimer, insanityLostInLoght, insanityLostNoLight, changeInputTimer, changeInputSoma;
    private string horizontal, vertical, horizontalInsane, verticalInsane;
    bool changeInput, can25, can75;

    [SerializeField] private Text subtitleText;
    [HideInInspector] public string doorColliderTxt;
    [SerializeField] Tutorial tutorial;

    float doorCounter;
    bool canWalk, canIncreaseInsanity;

    [SerializeField] AudioClip children;
    [SerializeField] AudioClip spongeBob;
    [SerializeField] AudioSource audioSrc;

    [SerializeField] Material wallMaterial;
    [SerializeField] Texture wallTex;
    [SerializeField] Texture bloodWallTex;

    void Awake()
    {
        subtitleText.text = "";
        canWalk = false;
    }

    private void Start()
    {
        lastInt = 1;
        insanity = 0;
        insanityTimer = 0;
        blueColor = new Color(0.012f, 0.016f, 0.095f);
        redColor = new Color(0.095f, 0.016f, 0.012f);
        RenderSettings.ambientLight = blueColor;
        fogParticle.SetActive(false);
        doorCounter = 0;
        can25 = false;
        can75 = false;
        canIncreaseInsanity = true;
    }

    private void Update()
    {
        if(tutorial.skipTuto || tutorial.sadasOpen)
        {
            canWalk = true;
        }

        if (canWalk)
        {
            horizontal = "Horizontal";
            vertical = "Vertical";
            horizontalInsane = "HorizontalInsane";
            verticalInsane = "VerticalInsane";

            ChangeInput();
        }
        
        PrivateLightController();

        if(firstBox)
        {
            RenderSettings.ambientLight = redColor;
            if (canIncreaseInsanity)
            {
                insanity += 25;
                canIncreaseInsanity = false;
            }
        }
        else RenderSettings.ambientLight = blueColor;

        // apresentaçao
        /*if(!tutorial.tutorial)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                insanity = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                insanity = 25;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                insanity = 50;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                insanity = 75;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                insanity = 100;
            }
        }*/

        if(insanity >= 0 && insanity < 25)
        {
            can25 = true;
            can75 = true;
            wallMaterial.mainTexture = wallTex;
        }
        if(insanity >= 25 && insanity < 50)
        {
            if(can25)
            {
                audioSrc.PlayOneShot(children);
                can25 = false;
            }
            can75 = true;
            wallMaterial.mainTexture = wallTex;
        }
        if(insanity >= 50 && insanity < 75)
        {
            wallMaterial.mainTexture = bloodWallTex;
        }
        if(insanity >= 75 && insanity < 100)
        {
            if (can75)
            {
                audioSrc.PlayOneShot(spongeBob);
                can75 = false;
            }
            can25 = true;
            wallMaterial.mainTexture = bloodWallTex;
        }
        if(insanity >= 100)
        {
            SceneManager.LoadScene("Defeat");
        }

        /*if(Input.GetKeyDown(KeyCode.Z))
        {
            fogParticle.SetActive(true);
        }*/
        
        if(insanity < 75)
        {
            changeInput = false;
        }
        else if(insanity >= 75)
        {
            changeInputSoma += Time.deltaTime;
            if(changeInputSoma >= changeInputTimer)
            {
                changeInput = !changeInput;
                changeInputSoma = 0;
            }
        }

        if(player.doorCollide)
        {
            doorCounter += Time.deltaTime;
            subtitleText.text = doorColliderTxt;

            if(doorCounter >= 3f)
            {
                subtitleText.text = "";
                player.doorCollide = false;
                doorCounter = 0;
            }
        }
    }

    private void ChangeInput()
    {
        if (changeInput)
        {
            player.horizontal = horizontalInsane;
            player.vertical = verticalInsane;
        }
        else
        {
            player.horizontal = horizontal;
            player.vertical = vertical;
        }

        insanityTimer += Time.deltaTime;
        if (player.inLight && insanityTimer >= insanityLostInLoght)
        {
            DecreaseInsanity();
        }
        else if (!player.inLight && insanityTimer >= insanityLostNoLight)
        {
            DecreaseInsanity();
        }
    }
    
    private void PrivateLightController()
    {
        globalLight.intensity = gLightInt;

        if (phoneMgn.inMenu || phoneMgn.phoneMode)
        {
            gLightInt = 0.5f;
        }
        else
        {
            // apresentacao
            /*gLightInt = lastInt;
            gLightInt += Input.GetAxis("Mouse ScrollWheel");
            gLightInt = Mathf.Clamp(gLightInt, 0, 4);
            lastInt = gLightInt;*/
        }
    }

    private void DecreaseInsanity()
    {
        insanity += 1;
        Debug.Log("Sanidade: " + insanity);
        insanityTimer = 0;
    }
}
