using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform toHoldPoint;

    public HoldPointScript holdScript;

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(GetComponent<Rigidbody>().position, GameObject.Find("HoldPoint").transform.position);

        print("The distance is: " + dist);

        if(dist <= 3)
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = toHoldPoint.position;
            this.transform.parent = GameObject.Find("HoldPoint").transform;
        }

        holdScript.setIsHolding(true);
        holdScript.setObjHolding(GetComponent<Rigidbody>().name);

    }

    private void OnMouseUp()
    {
        if(holdScript.getLookingAt() == "Build")
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;

            holdScript.setIsHolding(false);

            this.transform.position = new Vector3((float)-4.926, (float)2.3419, (float)4.103);
            this.transform.rotation = new Quaternion(0, -180, 0, 0);
        }
        else
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;

            holdScript.setIsHolding(false);
        }

    }
}
