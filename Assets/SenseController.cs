using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;

public class SenseController : MonoBehaviour
{
    public bool insideRange;

    public Sprite eyes;
    public Sprite ears;
    public Sprite empty;

    public void MouseEnter()
    {
        Debug.Log("On Portrait");
        insideRange = true;
    }

    public void MouseExit()
    {
        insideRange = false;
    }

    public void SetSense(string type)
    {
        Debug.Log("Set sense to: " + type);
        if (type == "Eyes")
        {
            RuntimeManager.StudioSystem.setParameterByName("Listening", 0f);
            GetComponent<Image>().sprite = eyes;
        }
        else
        {
            RuntimeManager.StudioSystem.setParameterByName("Listening", 1f);
            GetComponent<Image>().sprite = ears;
        }
    }
}
