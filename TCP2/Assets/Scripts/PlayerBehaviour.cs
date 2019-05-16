using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float gravity = -9.8f;
    private CharacterController charCont;
    private GameManager gameMng;
    private GameObject gameMngObj;
    private Light fLight;
    private bool isLighting, canBip;
    [SerializeField] AudioClip bipSound;

    public GameObject phone;
    public GameDesigner gameDesigner;

    private float goInsane;
    public float room1Time;
    [HideInInspector] public bool inLight, doorCollide;
    [HideInInspector] public string horizontal, vertical;
    Rigidbody body;
    Vector3 inputs = Vector3.zero;


    void Start ()
    {
        charCont = GetComponent<CharacterController>();
        fLight = GameObject.Find("Flashlight").GetComponent<Light>();
        fLight.enabled = false;
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameMngObj = GameObject.FindGameObjectWithTag("GameController");
        canBip = true;
        doorCollide = false;
        body = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        Flashlight();

        if(phone.GetComponent<PhoneManager>().locked)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Movement(gameDesigner.speed * gameDesigner.runSpeed);
            }
            else Movement(gameDesigner.speed);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Movement((gameDesigner.speed / gameDesigner.phoneSpeed) * gameDesigner.runSpeed);
            }
            else Movement(gameDesigner.speed / gameDesigner.phoneSpeed);
        }

        if (goInsane == 1)
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

    void Movement(float speedAtual)
    {
        float deltaX = Input.GetAxis(horizontal) * speedAtual;
        float deltaY = Input.GetAxis(vertical) * speedAtual;
        Vector3 movement = new Vector3(deltaX, 0, deltaY);
        movement = Vector3.ClampMagnitude(movement, speedAtual);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charCont.Move(movement);
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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag.Equals("Door"))
        {
            doorCollide = true;
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
