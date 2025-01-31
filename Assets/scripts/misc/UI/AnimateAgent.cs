using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateAgent : MonoBehaviour
{
    //Helper script to send triggers to the animator for the agent model
    public Animator[] animators;
    public List<Button> buttons;
  
    public void SendTrigger(string trigger)
    {
      //get the trigger for an animation
      SetButtonsInteractable(false); //disable the animation controls
      foreach (Animator animator in animators)
        {
            //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("idle"));
            animator.SetTrigger(trigger); //set the animation trigger
        }

      StartCoroutine(WaitForIdleState()); // wait for the idle
    }
    private void SetButtonsInteractable(bool interactable)
    {
        //reactivate buttons
        foreach (Button button in buttons)
        {
            button.interactable = interactable;
        }
    }

    private IEnumerator WaitForIdleState() //this function waits for the animator to be in its idle state before you can start another animation
    {
        yield return new WaitForSeconds(1f); // 1 second delay

        bool allIdle;
        do
        {
            allIdle = true;
            foreach (Animator animator in animators)
            {
                if (animator.gameObject.activeInHierarchy && !animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                {
                    allIdle = false;
                    break;
                }
            }
            // Wait for the next frame before checking again
            yield return null;
        } while (!allIdle);

        // Enable the buttons once all active animators are in the "idle" state
        SetButtonsInteractable(true);
    }
}
