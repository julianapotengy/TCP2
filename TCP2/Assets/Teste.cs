using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    float maxDistance = 10;

    void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) && hit.collider.gameObject.name.Equals("Busto"))
        {
            //this.enabled = false;
            Debug.Log("olhando");
        }
    }
}
