using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerCanvasController : MonoBehaviour
{
    public GameObject rulerCanvas;

    private bool rulerActive;

    public BuildState buildScript;

    void Start()
    {
        rulerCanvas.SetActive(false);
        rulerActive = false;
    }

    void Update()
    {
        //rulerState();

    }
    public void swapRulerState()
    {
        if (rulerActive == false)
        {
            rulerCanvas.SetActive(true);
            rulerActive = true;
            buildScript.setRulerCanvasOpen(true);
        }
        else
        {
            rulerCanvas.SetActive(false);
            rulerActive = false;
            buildScript.setRulerCanvasOpen(false);
        }
    }

    public bool getRulerActive()
    {
        return rulerActive;
    }
}
