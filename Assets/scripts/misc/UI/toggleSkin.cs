using UnityEngine;
using UnityEngine.UI;

public class toggleSkin : MonoBehaviour
{
    // A script in charge of the toggle of skin tones, this script ensures that no skin tone is not a selectable option
    public Toggle[] exclusiveToggles;
    public chooseAgent chooseScript;
    public string skinTone;

    private void Start()
    { 
        //default skintone 5
        chooseScript.setSkin("skintone 5");
        skinTone = "skintone 5";
        // Subscribe to the onValueChanged event of each toggle
        foreach (Toggle toggle in exclusiveToggles)
        {
            toggle.onValueChanged.AddListener((isOn) => OnToggleValueChanged(toggle, isOn));
        }
    }

    // Event handler for toggle value changes
    private void OnToggleValueChanged(Toggle currentToggle, bool isOn)
    {
        // Disable the current toggle when turned on, this way one skin tone must be chosen
        currentToggle.interactable = !isOn;

        if (isOn)
        {
            chooseScript.setSkin(currentToggle.name);
            skinTone = currentToggle.name;
            // If a toggle is turned on, turn off all other toggles, this way only one skintone can be chosen
            foreach (Toggle toggle in exclusiveToggles)
            {
                if (toggle != null && toggle != currentToggle)
                {
                    toggle.isOn = false;
                }
            }
        }
    }
}
