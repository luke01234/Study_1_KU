using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class toolTipper : MonoBehaviour
{
    //This is a small helper UI script built to change the tool tip text on the startup depending on where the mouse is.
    //each function is called depending on what the mouse is over
    public TextMeshProUGUI helperField;
    public void toolTipNone()
    {
      helperField.text = "Mouse Over an object for help...";
    }

    public void toolTipType()
    {
      helperField.text = "Choose what type of test this is.";
    }

    public void toolTipPID()
    {
      helperField.text = "Enter or generate the participants UNIQUE ID.";
    }
    
    public void toolTipSettings()
    {
      helperField.text = "Choose an experiment Settings profile.";
    }

    public void toolTipSaveDir()
    {
      helperField.text = "Choose a directory to save test results.";
    }

    public void toolTipSessionNum()
    {
      helperField.text = "Enter a session number for this test.";
    }

    public void toolTipExperimenterName()
    {
      helperField.text = "Enter the name of the person running this experiment (Your name). This field is optional.";
    }

    public void toolTipSubjectName()
    {
      helperField.text = "Enter the name of the person being experimented upon (In the headset). This field is optional.";
    }

    public void toolTipModel()
    {
      helperField.text = "Choose the agent model for this experiment.";
    }

    public void toolTipSkin()
    {
      helperField.text = "Choose the skin tone for the agent.";
    }
}
