using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAround : MonoBehaviour
{
    private PlayerBehaviour player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Light in scene"))
        {
            player.inLight = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Light in scene"))
        {
            player.inLight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Light in scene"))
        {
            player.inLight = false;
        }
    }
}
