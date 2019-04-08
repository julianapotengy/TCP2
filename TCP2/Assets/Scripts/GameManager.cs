using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    float gLightInt, lastInt;
    Color blueColor, redColor;
    
    [SerializeField] private PhoneManager phoneMgn;
    public float insanity;
    [HideInInspector] public bool firstBox;
    [SerializeField] private GameObject fogParticle;

    private void Start()
    {
        lastInt = 1;
        blueColor = new Color(0.012f, 0.016f, 0.095f);
        redColor = new Color(0.095f, 0.016f, 0.012f);
        RenderSettings.ambientLight = blueColor;
        fogParticle.SetActive(false);
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

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            fogParticle.SetActive(true);
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
}
