using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    float gLightInt, lastInt;
    
    [SerializeField] private PhoneManager phoneMgn;
    public float insanity;

    private void Start()
    {
        lastInt = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Game");
        }
        
        PrivateLightController();

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
    }
    
    private void PrivateLightController()
    {
        globalLight.intensity = gLightInt;

        if (phoneMgn.inMenu || phoneMgn.phoneMode)
        {
            gLightInt = 0;
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
