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
    bool changeInput;

    [SerializeField] private Text subtitleText;
    [HideInInspector] public string doorColliderTxt;

    float doorCounter;

    void Awake()
    {
        horizontal = "Horizontal";
        vertical = "Vertical";
        horizontalInsane = "HorizontalInsane";
        verticalInsane = "VerticalInsane";
        subtitleText.text = "";
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
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Game");
        }
        
        PrivateLightController();

        if(firstBox)
        {
            RenderSettings.ambientLight = redColor;
        }
        else RenderSettings.ambientLight = blueColor;

        // - comeco - apresentaçao
        if (Input.GetKeyDown(KeyCode.Alpha1))
            insanity = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            insanity = 25;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            insanity = 50;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            insanity = 75;
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            insanity = 100;

        if(Input.GetKeyDown(KeyCode.Z))
        {
            fogParticle.SetActive(true);
        }
        
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

        ChangeInput();

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
            gLightInt = lastInt;
            gLightInt += Input.GetAxis("Mouse ScrollWheel");
            gLightInt = Mathf.Clamp(gLightInt, 0, 3);
            lastInt = gLightInt;
        }
    }

    private void DecreaseInsanity()
    {
        insanity += 1;
        Debug.Log("Sanidade: " + insanity);
        insanityTimer = 0;
    }
}
