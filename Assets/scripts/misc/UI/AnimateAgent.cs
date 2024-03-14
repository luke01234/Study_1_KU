using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAgent : MonoBehaviour
{
    //Helper script to send triggers to the animator for the agent model
    public Animator[] animators;
  
    public void SendTrigger(string trigger)
    {
      foreach (Animator animator in animators)
        {
            animator.SetTrigger(trigger);
        }
    }
}
