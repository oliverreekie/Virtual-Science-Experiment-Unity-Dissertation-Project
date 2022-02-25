using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour

{
    public Transform playerBody;

    public GameObject rulerCanvas;

    private bool rulerActive;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockedMode.Locked;
        rulerCanvas.SetActive(false);
        rulerActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        rulerState();

        if (rulerActive == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);

            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    void rulerState()
    {
        if (Input.GetKeyDown("e"))
        {
            if (rulerActive == false)
            {
                rulerCanvas.SetActive(true);
                rulerActive = true;
            }
            else
            {
                rulerCanvas.SetActive(false);
                rulerActive = false;
            }
        }
    }
}
