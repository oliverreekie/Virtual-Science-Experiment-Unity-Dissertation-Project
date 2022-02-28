using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class ArrowScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;

    public TextMeshProUGUI distanceText;

    private double arrowLocation;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        print("Hold");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        print("Release");
    }

    private void Update()
    {
        if(isHolding == true){
            arrowLocation = Math.Round((this.transform.position.x - 629.3) / 25.582);
            print(arrowLocation);
            distanceText.text = (arrowLocation.ToString() + "cm");
            if(this.transform.position.x <= 629.3)
            {
                this.transform.position = new Vector3((float)629.6, this.transform.position.y, this.transform.position.z);
            }
            else if(this.transform.position.x >= 1908.4)
            {
                this.transform.position = new Vector3((float)1908.1, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                this.transform.position = new Vector3(Input.mousePosition.x, this.transform.position.y, this.transform.position.z);
            }
        }
    }

    public double getArrowLocation()
    {
        return arrowLocation;
    }

}
