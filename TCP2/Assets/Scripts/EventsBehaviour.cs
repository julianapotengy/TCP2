using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBehaviour : MonoBehaviour 
{
    GameObject quadro;
    GameObject book;
    bool leftRoom;
    float quadroPosition;
    Vector3 bookPosition;

    void Awake()
    {
        quadro = GameObject.Find("Quadro");
        book = GameObject.Find("Book");
        quadroPosition = quadro.transform.position.y;
        bookPosition = book.transform.position;
    }

	void Start ()
    {
        leftRoom = true;
	}
	
	void Update ()
    {
        if(leftRoom)
        {
            QuadroCaindo();
        }
    }

    void QuadroCaindo()
    {
        if (quadro.transform.position.y >= 0.6f)
        {
            quadroPosition -= 0.05f;
            quadro.transform.position = new Vector3(quadro.transform.position.x, quadroPosition, quadro.transform.position.z);
        }
    }
}
