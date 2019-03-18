using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    float gLightInt, lastInt;
    [SerializeField] private GameObject img1;
    bool trigger1;
    [SerializeField] private PhoneManager phoneMgn;

    private void Start()
    {
        lastInt = 1;
        trigger1 = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            trigger1 = true;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Game");
        }

        if(trigger1)
        {
            img1.SetActive(true);
        }
        else if(!trigger1)
        {
            img1.SetActive(false);
        }
        
        PrivateLightController();
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
