using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBehaviour : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Start ()
    {
		
	}
	
	void Update ()
    {
        //this.transform.LookAt(player.transform);
        Vector3 playerPosisiton = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosisiton);
    }
}
