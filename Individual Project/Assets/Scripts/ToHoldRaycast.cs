using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToHoldRaycast : MonoBehaviour
{
    public Text uiText;

    public HoldPointScript holdScript;

    public BuildState buildScript;

    void Update()
    {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
            {

                if(holdScript.getIsHolding() == true)
                {
                    if (hit.collider.name == "BuildObjCheck")
                    {
                        if( (buildScript.getBuildState() == "Nothing" && holdScript.getObHolding() == "ClampStand") ||
                            (buildScript.getBuildState() == "ClampStand" && holdScript.getObHolding() == "LightGate_Off") ||
                            (buildScript.getBuildState() == "ClampStand, LGOff" && holdScript.getObHolding() == "Ruler") ||
                            (buildScript.getBuildState() == "Ruler, Clamp, LGOFF" && holdScript.getObHolding() == "Timer") ||
                            (buildScript.getBuildState() == "Ruler, Clamp, LGOFF, Timer" && holdScript.getObHolding() == "Wires") )
                        {
                            uiText.text = "Build";
                            holdScript.setLookingAt("Build");
                        }

                    }
                    else if (hit.collider.name == "Ruler, Clamp, LGON, Timer, Wires")
                    {
                        if(holdScript.getObHolding() == "Weighted Card"){
                            uiText.text = "Drop";
                            holdScript.setLookingAt("Ruler, Clamp, LGON, Timer, Wires");
                        }

                    }
                    else
                    {
                        uiText.text = ("");
                        holdScript.setLookingAt("Nothing");
                    }
                    
                }
                else if (hit.collider.name != "BuildObjCheck" && hit.collider.name != "Ruler, Clamp, LGON, Timer, Wires")
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
