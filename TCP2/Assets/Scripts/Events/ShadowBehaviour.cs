using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBehaviour : MonoBehaviour
{
    GameObject player;
    [HideInInspector] public bool canFollow;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        if (canFollow)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= 5)
            {
                transform.LookAt(player.transform);
                transform.position += transform.forward * 4 * Time.deltaTime;
            }
        }
	}
}
