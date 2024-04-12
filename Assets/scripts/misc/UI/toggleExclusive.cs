using UnityEngine;
using UnityEngine.UI;

public class toggleExclusive : MonoBehaviour
{
    //This is a script to toggle the value of the agents gender, exclusive toggle so that no gender is not an option
    public Toggle toggle1;
    public Toggle toggle2;
    public chooseAgent chooseScript;
    public string curModel;
    private void Start()
    {
        //set toggle 1 on by default, listen for changes in the toggles, if there is a change in one, make the opposite change to another
        toggle1.isOn=true;
        curModel = "Female";
        toggle1.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle1); });
        toggle2.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle2); });
    }

    private void OnToggleValueChanged(Toggle toggle)
    {
      //flip the opposite toggle off if one is turned on, or on if one is turned off (basically remove the posibility of neither being selected)
        if (toggle.isOn)
        {
            // If toggle1 is selected, unselect toggle2 and vice versa
            if (toggle == toggle1)
            {
                toggle2.isOn = false;
                curModel = "Female";
            }
            else if (toggle == toggle2)
            {
                toggle1.isOn = false;
                curModel = "Male";
            }
        }
        else
        {
            // If one toggle is turned off, turn the other one on
            if (toggle == toggle1)
            {
                toggle2.isOn = true;
                curModel = "Male";
            }
            else if (toggle == toggle2)
            {
                toggle1.isOn = true;
                curModel = "Female";
            }
        }
        chooseScript.maleFigure = toggle2.isOn;
        chooseScript.setModel();
    }
}
