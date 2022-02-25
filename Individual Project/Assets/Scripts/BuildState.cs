using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : MonoBehaviour
{
    private string buildState = "Nothing";

    public GameObject clampStand;

    public GameObject clampStandLGOFF;

    public GameObject clampStandLGOFFRuler;

    public GameObject clampStandLGOFFRulerTimer;

    public GameObject buildCheck;

    public void Update()
    {
        if(buildState == "ClampStand, LGOff")
        {
            Destroy(clampStand);
        }
        if (buildState == "Ruler, Clamp, LGOFF")
        {
            Destroy(clampStandLGOFF);
        }
        if (buildState == "Ruler, Clamp, LGOFF, Timer")
        {
            Destroy(clampStandLGOFFRuler);
        }
        if (buildState == "Ruler, Clamp, LGOFF, Timer, Wires")
        {
            Destroy(clampStandLGOFFRulerTimer);
            Destroy(buildCheck);
        }
    }

    public void setBuildState(string s)
    {
        buildState = s;
    }

    public string getBuildState()
    {
        return buildState;
    }
}
