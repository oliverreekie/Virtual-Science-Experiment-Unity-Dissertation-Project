using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WiresScript : MonoBehaviour
{
    private bool running = false;

    private double timer = 0;

    public TextMeshPro uiText;

    // Update is called once per frame
    void Update()
    {
        if(running == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            print(timer);
            double toPrint = Math.Round((timer * 10), 2);
            uiText.text = toPrint.ToString();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collide");
        running = true;
        timer = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        print("");
        running = false;
    }
}
