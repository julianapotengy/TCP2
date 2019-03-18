using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speed = 6.0f;
    private float gravity = -9.8f;
    private CharacterController charCont;
    private Light fLight;
    private bool isLighting;

    public GameObject phone;
    
	void Start ()
    {
        charCont = GetComponent<CharacterController>();
        fLight = GameObject.Find("Flashlight").GetComponent<Light>();
        fLight.enabled = false;
	}
	
	void Update ()
    {
        Movement();
        Flashlight();
	}

    void Movement()
    {
        if(!phone.GetComponent<PhoneManager>().phoneMode)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaY = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaY);
            movement = Vector3.ClampMagnitude(movement, speed);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            charCont.Move(movement);
        }
    }

    void Flashlight()
    {
        if(!phone.GetComponent<PhoneManager>().phoneMode)
        {
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.R))
            {
                fLight.enabled = !fLight.enabled;
            }
        }
    }
}
