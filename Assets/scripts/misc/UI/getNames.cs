using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;


public class getNames : MonoBehaviour
{
    //helper script to get the names of experimenter and subject
    public Text experimenter, subject, testType;
    public trackAVGs tracker;
    public void onStart()
    {
      //send the following info to the tracker from the UI
      tracker.experimenter = experimenter.text;
      tracker.subject = subject.text;
      tracker.testType = testType.text; 
    }
}
