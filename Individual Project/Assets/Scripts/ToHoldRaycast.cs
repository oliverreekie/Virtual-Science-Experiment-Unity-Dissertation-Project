using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHoldRaycast : MonoBehaviour
{

    public Text uiText;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            //print("Did Hit: " + hit.rigidbody.name);
            uiText.text = ("Pick up component");
        }
        else
        {
            //print("Did not Hit");
            uiText.text = "";
        }
    }
}
