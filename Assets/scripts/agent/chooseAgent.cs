using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class chooseAgent : MonoBehaviour
{
    // Script in charge of editing the agent depending on the selected options in the start up screen
    public bool maleFigure = false;
    public Material[] skinTones;
    public Material[] maleFaces;
    public Material[] femaleFaces;
    public int skinChoice = 4;
    Transform male, female;
    public GameObject maleModel, femaleModel;
    Renderer[] maleRenderers, femaleRenderers;

    void Start()
    {
      //initialize variables
      male = transform.GetChild(0);
      female = transform.GetChild(1);
      maleRenderers = maleModel.GetComponentsInChildren<Renderer>();
      femaleRenderers = femaleModel.GetComponentsInChildren<Renderer>();
    }

    public void setSkin(string skinTone)
    {
      //function responsible for assigning the skin tone of the characters
      switch (skinTone)
      {
          case "skintone 1":
              skinChoice = 0;
              break;
          case "skintone 2":
              skinChoice = 1;
              break;
          case "skintone 3":
              skinChoice = 2;
              break;
          case "skintone 4":
              skinChoice = 3;
              break;
          case "skintone 5":
              skinChoice = 4;
              break;
          case "skintone 6":
              skinChoice = 5;
              break;
          case "skintone 7":
              Debug.Log("Matching skintone 7");
              skinChoice = 6;
              break;
          case "skintone 8":
              skinChoice = 7;
              break;
      }

      foreach (Renderer renderer in maleRenderers)
        {
            // Check if the current material's name matches the specified name
            if (renderer.material.name.Contains("Wolf3D_Body") || (renderer.material.name.Contains("skin")))
            {
              renderer.material = skinTones[skinChoice];
            }
            else if (renderer.material.name.Contains("Wolf3D_Skin") || (renderer.material.name.Contains("skin")))
            {
              renderer.material = maleFaces[skinChoice];
            }
        }
      foreach (Renderer renderer in femaleRenderers)
        {
            // Check if the current material's name matches the specified name
            if (renderer.material.name.Contains("Wolf3D_Body") || (renderer.material.name.Contains("skin")))
            {
              renderer.material = skinTones[skinChoice];
            }
            else if (renderer.material.name.Contains("Wolf3D_Skin") || (renderer.material.name.Contains("skin")))
            {
              renderer.material = femaleFaces[skinChoice];
            }
        }
    }

    public void setModel()
    {
      //function responsible for setting the character gender
      male.gameObject.SetActive(maleFigure);
      female.gameObject.SetActive(!maleFigure);
    }
}
