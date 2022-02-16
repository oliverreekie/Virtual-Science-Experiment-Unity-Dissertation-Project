using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHoldRaycast : MonoBehaviour
{
    public Text uiText;

    public HoldPointScript holdScript;

    void Update()
    {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
            {

                if(holdScript.getIsHolding() == true)
                {
                    if (hit.collider.name == "BuildObjCheck")
                    {
                        uiText.text = "Build";
                        holdScript.setLookingAt("Build");
                    }
                    else
                    {
                        uiText.text = ("");
                        holdScript.setLookingAt("Nothing");
                    }
                    
                }
                else if (hit.collider.name != "BuildObjCheck")
                {
                    uiText.text = ("Pick up");
                    holdScript.setLookingAt("Object");
                }

            }
            else
            {
                uiText.text = "";
                holdScript.setLookingAt("Nothing");
            }
    }
}
