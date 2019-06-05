using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float gravity = -9.8f;
    private CharacterController charCont;
    private GameManager gameMng;
    private GameObject gameMngObj;
    private bool isLighting, canBip;
    [SerializeField] AudioClip bipSound;

    public GameObject phone;
    public GameDesigner gameDesigner;
    EventsBehaviour eventsBehaviour;
    public Tutorial tutorialObj;

    private float goInsane;
    public float room1Time;
    [HideInInspector] public bool inLight, doorCollide, canWalk;
    [HideInInspector] public string horizontal, vertical;
    Rigidbody body;
    Vector3 inputs = Vector3.zero;

    [SerializeField] AudioSource walkSrc;

    void Start ()
    {
        charCont = GetComponent<CharacterController>();
        gameMngObj = GameObject.FindGameObjectWithTag("GameController");
        gameMng = gameMngObj.GetComponent<GameManager>();
        eventsBehaviour = gameMngObj.GetComponent<EventsBehaviour>();
        //tutorialObj = GameObject.Find("Tutorial").GetComponent<Tutorial>();
        canBip = true;
        doorCollide = false;
        body = GetComponent<Rigidbody>();
        walkSrc.enabled = false;
        canWalk = false;
    }
	
	void Update ()
    {
        if(tutorialObj.sadasOpen)
        {
            canWalk = true;
        }
        
        if(canWalk)
        {
            if (phone.GetComponent<PhoneManager>().locked)
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

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                walkSrc.enabled = true;
            }
            else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
            {
                walkSrc.enabled = false;
            }
        }

        if (!tutorialObj.tutorial)
        {
            if (goInsane == 1)
            {
                room1Time += Time.deltaTime;
            }
            if (room1Time >= 5 && canBip)
            {
                gameMngObj.GetComponent<AudioSource>().PlayOneShot(bipSound);
                canBip = false;
            }

            if (goInsane >= 2)
            {
                gameMng.firstBox = true;
            }
        }
	}

    void Movement(float speedAtual)
    {
        if(tutorialObj.tutoWalk && tutorialObj.tutorial)
        {
            float deltaX = Input.GetAxis(horizontal) * speedAtual;
            float deltaY = Input.GetAxis(vertical) * speedAtual;
            Vector3 movement = new Vector3(0, 0, deltaY);
            movement = Vector3.ClampMagnitude(movement, speedAtual);

            movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            charCont.Move(movement);
        }
        else if(!tutorialObj.tutorial)
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
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag.Equals("Desmoronamento"))
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
        if (other.gameObject.name.Equals("Sala1Esquerda"))
        {
            eventsBehaviour.leftRoom += 1;
            if(eventsBehaviour.leftRoom == 3)
            {
                eventsBehaviour.ShadowGone();
            }
        }
        if(other.gameObject == eventsBehaviour.passosLeftRoom)
        {
            eventsBehaviour.ShadowGone();
        }
        if(other.gameObject.name.Equals("RightCollider_LeftEvent"))
        {
            eventsBehaviour.shadowLeftRoom.GetComponent<ShadowBehaviour>().canFollow = true;
        }

        if(tutorialObj.tutorial && other.gameObject.name.Equals("BustoTutorial"))
        {
            tutorialObj.bustoCollide = true;
            tutorialObj.counter = 0;
            tutorialObj.sadasOpen = false;
            gameMngObj.GetComponent<AudioSource>().PlayOneShot(bipSound);
        }
    }
}
