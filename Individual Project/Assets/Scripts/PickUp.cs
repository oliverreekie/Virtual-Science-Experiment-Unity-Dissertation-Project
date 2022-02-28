using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform toHoldPoint;

    public HoldPointScript holdScript;

    public BuildState buildScript;

    public GameObject toInstantiate;

    public RulerCanvasController rulerController;

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(GetComponent<Rigidbody>().position, GameObject.Find("HoldPoint").transform.position);

        string name = GetComponent<Rigidbody>().name;

        if(dist <= 3)
        {
            if(GetComponent<Rigidbody>().name != "ClampStand_LGOFF" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGOFF" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGOFF, Timer" && GetComponent<Rigidbody>().name != "Ruler, Clamp, LGON, Timer, Wires")
            {
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = toHoldPoint.position;
                this.transform.parent = GameObject.Find("HoldPoint").transform;

                holdScript.setIsHolding(true);
                holdScript.setObjHolding(GetComponent<Rigidbody>().name);
            }
        }
    }

    private void OnMouseUp()
    {
        if (holdScript.getLookingAt() == "Build")
        {
            this.transform.parent = null;

            GetComponent<Rigidbody>().useGravity = true;

            holdScript.setIsHolding(false);
            
            if (buildScript.getBuildState() == "Nothing" && holdScript.getObHolding() == "ClampStand")
            {
                this.transform.position = new Vector3((float)-5.057, (float)2.206, (float)5.218);
                this.transform.rotation = new Quaternion(0, -180, 0, 0);
                buildScript.setBuildState("ClampStand");
            }
            else if (buildScript.getBuildState() == "ClampStand" && holdScript.getObHolding() == "LightGate_Off")
            {
                buildScript.setBuildState("ClampStand, LGOff");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.052, (float)2.208, (float)5.226);
                
            }
            else if (buildScript.getBuildState() == "ClampStand, LGOff" && holdScript.getObHolding() == "Ruler")
            {
                buildScript.setBuildState("Ruler, Clamp, LGOFF");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.063, (float)2.207, (float)4.229);
                
            }
            else if (buildScript.getBuildState() == "Ruler, Clamp, LGOFF" && holdScript.getObHolding() == "Timer")
            {
                buildScript.setBuildState("Ruler, Clamp, LGOFF, Timer");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.06, (float)2.206, (float)4.224); 
            }
            else if (buildScript.getBuildState() == "Ruler, Clamp, LGOFF, Timer" && holdScript.getObHolding() == "Wires")
            {
                buildScript.setBuildState("Ruler, Clamp, LGOFF, Timer, Wires");
                Destroy(gameObject);

                toInstantiate.transform.position = new Vector3((float)-5.06, (float)2.206, (float)4.224);
            }
        }
        else if (holdScript.getLookingAt() == "Ruler, Clamp, LGON, Timer, Wires" && holdScript.getObHolding() == "Weighted Card")
        {
            rulerController.swapRulerState();
        }
        else
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;

            holdScript.setIsHolding(false);
        }

    }

    public void droppingCardFromRuler()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;

        holdScript.setIsHolding(false);
    }
}
