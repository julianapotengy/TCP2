using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameDesigner : MonoBehaviour
{
    [Header("Velocidade normal do jogador")]
    public float speed;
    [Header("velocidade do jogador * runSpeed = correr")]
    public float runSpeed;
    [Header("velocidade do jogador / phoneSpeed = no celular")]
    public float phoneSpeed;

    [Header("Ângulo da lanterna (min 1 max 179)")]
    public float flashlightSpotAngle;
    [Header("Range da lanterna (min 0)")]
    public float flashlightRange;

    [Header("Perda de insanidade com luz")]
    public float insanityLostInLight;
    [Header("Perda de insanidade sem luz")]
    public float insanityLostNoLight;
    [Header("Tempo de mudança de botões")]
    public float changeInputTimer;

    private Light flashlight;
    private GameManager gameMng;

    void Awake()
    {
        flashlight = GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Light>();
        gameMng = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
        flashlight.spotAngle = flashlightSpotAngle;
        flashlight.range = flashlightRange;
        gameMng.insanityLostInLoght = insanityLostInLight;
        gameMng.insanityLostNoLight = insanityLostNoLight;
        gameMng.changeInputTimer = changeInputTimer;
	}
}
