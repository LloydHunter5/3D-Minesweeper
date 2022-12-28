using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundMiddle : MonoBehaviour
{

    [SerializeField] int SENSITIVITY;
    private bool mousePressed;
    private float lastMouseX;

    // Start is called before the first frame update
    void Start()
    {
        GlobalConstants.SENSITIVITY = SENSITIVITY;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalConstants.gameHasStarted)
        {
            RotateCamera();
        }
        else
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, Time.deltaTime);
        }
    }

    void RotateCamera()
    {
        //--------ROTATION---------
        //Checks if mouse is pressed
        if (Input.GetButtonDown("LeftClick"))
        {
            lastMouseX = 0;
            mousePressed = true;
        }
        if (Input.GetButtonUp("LeftClick"))
        {
            lastMouseX = Input.GetAxis("Mouse X");
            mousePressed = false;
        }

        //While lmb is held down, rotate the camera around 0,0,0
        if (mousePressed)
        {
            float mouseX = Input.GetAxis("Mouse X");
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, GlobalConstants.SENSITIVITY * -mouseX * Time.deltaTime);
        }
        //Once lmb is released, slowly reduce rotation speed until it is no longer noticeable, then stop
        else if (Mathf.Abs(lastMouseX) > 0)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, GlobalConstants.SENSITIVITY * -lastMouseX * Time.deltaTime);
            lastMouseX /= Mathf.Pow(4, Time.deltaTime);
            if (Mathf.Abs(lastMouseX) <= 0.001)
            {
                lastMouseX = 0;
            }
        }

        //--------ZOOM----------
        if (Input.mouseScrollDelta.y != 0)
        {
            float scrollAmount = Input.mouseScrollDelta.y;
            gameObject.transform.Translate(0, 0, scrollAmount);
        }
    }
}
