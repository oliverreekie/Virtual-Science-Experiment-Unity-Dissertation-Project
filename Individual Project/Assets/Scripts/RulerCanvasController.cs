using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerCanvasController : MonoBehaviour
{
    public GameObject rulerCanvas;

    private bool rulerActive;

    public GameObject notesCanvas;

    private bool notesActive;

    void Start()
    {
        rulerCanvas.SetActive(false);
        rulerActive = false;

        notesCanvas.SetActive(false);
        notesActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            swapNotesState();
        }
    }

    public void swapRulerState()
    {
        if (rulerActive == false)
        {
            rulerCanvas.SetActive(true);
            rulerActive = true;
            BuildState.Instance.setRulerCanvasOpen(true);
        }
        else
        {
            rulerCanvas.SetActive(false);
            rulerActive = false;
            BuildState.Instance.setRulerCanvasOpen(false);
        }
    }
    public void swapNotesState()
    {
        if (notesActive == false)
        {
            notesCanvas.SetActive(true);
            notesActive = true;
            BuildState.Instance.setNotesCanvasOpen(true);
        }
        else
        {
            notesCanvas.SetActive(false);
            notesActive = false;
            BuildState.Instance.setNotesCanvasOpen(false);
        }
    }

    public bool getRulerActive()
    {
        return rulerActive;
    }
    public bool getNotesActive()
    {
        return notesActive;
    }
}
