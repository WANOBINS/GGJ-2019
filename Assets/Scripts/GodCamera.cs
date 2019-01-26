using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCamera : MonoBehaviour
{
    private Camera GodsEye;
    [SerializeField]
    private float flySpeed = .25f;
    [SerializeField]
    private float zoomSpeed = 1.5f;
    public float lookSensitivity = 1.5f;    
    private bool camRotate = false;
    private float rotateX;
    private float rotateY;
	// Use this for initialization
	void Awake ()
    {
        GodsEye = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float ActiveFlySpeed;

        if(Input.GetKey(KeyCode.LeftShift))
            ActiveFlySpeed = 2 * flySpeed;
        else
            ActiveFlySpeed = flySpeed;

        camRotate = Input.GetMouseButton(1);

        if(camRotate)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            rotateX = Input.GetAxis("Mouse X");
            rotateY = Input.GetAxis("Mouse Y");

            rotateX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * lookSensitivity;
            rotateY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * lookSensitivity;
            GodsEye.transform.localEulerAngles = new Vector3(rotateY, rotateX, 0f);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        GodsEye.transform.localPosition += (transform.forward * Input.mouseScrollDelta.y) * zoomSpeed;

        GodsEye.transform.localPosition += ((transform.right * Input.GetAxis("Horizontal") * ActiveFlySpeed) + (transform.forward * Input.GetAxis("Vertical") * ActiveFlySpeed))/2;
    }
}
