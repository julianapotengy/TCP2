using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speed = 6.0f;
    private float gravity = -9.8f;
    private CharacterController charCont;
    private Light flight;
    private bool isLighting;
    
	void Start ()
    {
        charCont = GetComponent<CharacterController>();
        flight = GameObject.Find("Flashlight").GetComponent<Light>();
	}
	
	void Update ()
    {
        Movement();
        Flashlight();
	}

    void Movement()
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

    void Flashlight()
    {
        if(Input.GetMouseButtonDown(1))
        {
            flight.enabled = !flight.enabled;
        }
    }
}
