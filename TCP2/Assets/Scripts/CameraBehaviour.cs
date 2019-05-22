using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject phone;
    public Tutorial tutorialObj;

    public enum RotationAxis
    {
        mouseX = 1, mouseY = 2
    }

    public RotationAxis axes = RotationAxis.mouseX;

    private float minimumVert = -45.0f;
    private float maximumVert = 45.0f;
    private float senseHorizontal = 10.0f;
    private float senseVertical = 10.0f;

    private float rotationX = 0;
	
	void Update ()
    {
        if(!tutorialObj.tutorial)
        {
            if (!phone.GetComponent<PhoneManager>().phoneMode)
            {
                if (axes == RotationAxis.mouseX)
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * senseHorizontal, 0);
                }
                else if (axes == RotationAxis.mouseY)
                {
                    rotationX -= Input.GetAxis("Mouse Y") * senseVertical;
                    rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

                    float rotationY = transform.localEulerAngles.y;
                    transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
                }
            }
        }
	}
}
