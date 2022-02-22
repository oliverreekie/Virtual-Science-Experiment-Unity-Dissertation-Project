using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldPointScript : MonoBehaviour
{

    private bool isHolding = false;

    private string objHolding = "";

    private string lookingAt = "";

    public void setIsHolding(bool b)
    {
        isHolding = b;
    }

    public bool getIsHolding()
    {
        return isHolding;
    }

    public void setObjHolding(string s)
    {
        objHolding = s;
    }

    public string getObHolding()
    {
        return objHolding;
    }

    /*public void setBuildState(string s)
    {
        buildState = s;
    }

    public string getBuildState()
    {
        return buildState;
    }*/
    public void setLookingAt(string s)
    {
        lookingAt = s;
    }

    public string getLookingAt()
    {
        return lookingAt;
    }
}
