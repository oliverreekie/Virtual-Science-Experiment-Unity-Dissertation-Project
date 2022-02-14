using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform toHoldPoint;

    private void OnMouseDown()
    {
        float dist = Vector3.Distance(GetComponent<Rigidbody>().position, GameObject.Find("HoldPoint").transform.position);

        print("The distance is: " + dist);

        if(dist <= 2)
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = toHoldPoint.position;
            this.transform.parent = GameObject.Find("HoldPoint").transform;
        }

    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
