using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    float maxDistance = 10;
    EventsBehaviour eventsBehaviour;

    void Start ()
    {
        eventsBehaviour = GameObject.FindGameObjectWithTag("GameController").GetComponent<EventsBehaviour>();
	}
	
	void FixedUpdate ()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.name.Equals("ShadowLeftRoom") && eventsBehaviour.shadowLeftRoom.GetComponent<ShadowBehaviour>().canFollow)
        {
            Destroy(eventsBehaviour.passosLeftRoom);
            //eventsBehaviour.passosLeftRoom.SetActive(false);
        }
    }
}
