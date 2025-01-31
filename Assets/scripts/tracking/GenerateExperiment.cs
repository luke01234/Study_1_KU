using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class GenerateExperiment : MonoBehaviour
{
  //script to generate the experiment with 4 trails
  public Block myBlock;
  public void Generate(Session uxfSession)
  {
    myBlock = uxfSession.CreateBlock(4);
  }
}
