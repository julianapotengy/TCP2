using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speed = 6.0f;
    private float gravity = -9.8f;
    private CharacterController charCont;
    
	void Start ()
    {
        charCont = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        Movement();
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
}
