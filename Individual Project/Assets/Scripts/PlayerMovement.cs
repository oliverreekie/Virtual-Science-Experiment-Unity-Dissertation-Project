using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 0.1f;

    public GameObject newObj;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            Instantiate(newObj, new Vector3((float)-4.926, (float)2.3419, (float)4.103), new Quaternion(0, 0, 0, 0));
        }
    }

}
