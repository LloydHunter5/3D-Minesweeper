using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool mousePressed;
    private float lastMouseY;

    // Update is called once per frame
    void Update()
    {
        if (GlobalConstants.gameHasStarted)
        {
            rotateGrid();
        }
        else
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.down, 10 * Time.deltaTime);
            gameObject.transform.RotateAround(Vector3.zero, Vector3.right, 8 * Time.deltaTime);
        }
    }

    private void rotateGrid()
    {
        //--------ROTATION---------
        //Checks if mouse is pressed
        if (Input.GetButtonDown("LeftClick"))
        {
            lastMouseY = 0;
            mousePressed = true;
        }
        if (Input.GetButtonUp("LeftClick"))
        {
            lastMouseY = Input.GetAxis("Mouse Y");
            mousePressed = false;
        }

        //While lmb is held down, rotate the camera around 0,0,0
        if (mousePressed)
        {
            float mouseY = Input.GetAxis("Mouse Y");
            gameObject.transform.RotateAround(Vector3.zero, Camera.main.transform.right, GlobalConstants.SENSITIVITY * mouseY * Time.deltaTime);
        }
        //Once lmb is released, slowly reduce rotation speed until it is no longer noticeable, then stop
        else if (Mathf.Abs(lastMouseY) > 0)
        {
            gameObject.transform.RotateAround(Vector3.zero, Camera.main.transform.right, GlobalConstants.SENSITIVITY * lastMouseY * Time.deltaTime);
            lastMouseY /= Mathf.Pow(4, Time.deltaTime);
            if (Mathf.Abs(lastMouseY) <= 0.001)
            {
                lastMouseY = 0;
            }
        }
    }
}
