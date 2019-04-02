using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float speed = 6.0f;
    private float gravity = -9.8f;
    private CharacterController charCont;
    private GameManager gameMng;
    private GameObject gameMngObj;
    private Light fLight;
    private bool isLighting, canBip;
    [SerializeField] AudioClip bipSound;

    public GameObject phone;

    private int goInsane;
    public float room1Time;
    
	void Start ()
    {
        charCont = GetComponent<CharacterController>();
        fLight = GameObject.Find("Flashlight").GetComponent<Light>();
        fLight.enabled = false;
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameMngObj = GameObject.FindGameObjectWithTag("GameController");
        canBip = true;
    }
	
	void Update ()
    {
        Movement();
        Flashlight();

        if(goInsane == 1)
        {
            room1Time += Time.deltaTime;
        }
        if(room1Time >= 5 && canBip)
        {
            gameMngObj.GetComponent<AudioSource>().PlayOneShot(bipSound);
            canBip = false;
        }

        if(goInsane >= 2)
        {
            gameMng.firstBox = true;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Insane"))
        {
            goInsane += 1;
        }
    }
}
