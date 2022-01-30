using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModeSwitcher : MonoBehaviour
{
    public enum SwitchType { Eyes, Ears};
    public SwitchType switchType;

    public GameObject eyeDragger;
    public GameObject earDragger;

    SenseController senseController;

    bool dragging;

    // Start is called before the first frame update
    void Start()
    {
        senseController = GameObject.Find("Portrait").GetComponent<SenseController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            switch (switchType)
            {
                case SwitchType.Ears:
                    earDragger.transform.position = Input.mousePosition;
                    break;
                case SwitchType.Eyes:
                    eyeDragger.transform.position = Input.mousePosition;
                    break;
            }
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Start Drag.");
        switch(switchType)
        {
            case SwitchType.Ears:
                earDragger.SetActive(true);
                earDragger.transform.position = Input.mousePosition;
                break;
            case SwitchType.Eyes:
                eyeDragger.SetActive(true);
                eyeDragger.transform.position = Input.mousePosition;
                break;
        }
        dragging = true;
    }

    public void OnMouseUp()
    {
        Debug.Log("End Drag.");
        //do end drag stuff
        dragging = false;
        switch (switchType)
        {
            case SwitchType.Ears:
                earDragger.SetActive(false);
                break;
            case SwitchType.Eyes:
                eyeDragger.SetActive(false);
                break;
        }
        if(senseController.insideRange)
        {
            if(switchType == SwitchType.Eyes)
                senseController.SetSense("Eyes");
            else
                senseController.SetSense("Ears");
        }
    }
}
