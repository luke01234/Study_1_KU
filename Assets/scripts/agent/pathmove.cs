using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;
using UXF;

public class pathmove : MonoBehaviour
{
    //script to move the characters along a set of path points
    private Animator animator;
    public chooseAgent chooseScript;
    public  UnityEngine.UI.Button[] buttons;
    private lookAtTarget lookScript;
    public Transform[] pathPoints;
    public int currentPointIndex;
    public Vector3 startPos;

    public float speed = 3f;

    private float startTime;
    private float journeyLength;
    public float rotationSpeed = 1f;

    public Session session;

    private void Start()
    {   
      //initialize some scripts and animators
      lookScript = GetComponent<lookAtTarget>();
      chooseScript = transform.GetComponent<chooseAgent>();
      if (chooseScript.maleFigure)
      {
        animator = transform.GetChild(0).GetComponent<Animator>();
      }
      else
      {
        animator = transform.GetChild(1).GetComponent<Animator>();
      }
      //send walking trigger 
      animator.SetTrigger("startWalking");
      currentPointIndex = -1;
      NextPoint();
    }

    private void NextPoint()
    {
      // increment walking point
        currentPointIndex += 1;
        if (currentPointIndex >= pathPoints.Length) //if we are on the final point or more, stop walking and make the animations for waving and what not usable also end trial and disable this script
        {
            currentPointIndex = pathPoints.Length-1;
            animator.SetTrigger("stopWalking");
            lookScript.enabled=true;
            foreach ( UnityEngine.UI.Button button in buttons)
            {
              button.interactable  = true;
            }
            session.GetTrial().End();
            enabled=false;
        }
        //calculations for the LERP between points
        startTime = Time.time;
        startPos=transform.position;
        journeyLength = Vector3.Distance(startPos, pathPoints[currentPointIndex].position);
    }
    private void Update()
    {   
        if (Vector3.Distance(transform.position, pathPoints[currentPointIndex].position) <= .5f) //if at a point move to next point
        {
            NextPoint();
        }
        else
        {
            //otherwise, linear interpolate towards current point
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPos, pathPoints[currentPointIndex].position, fractionOfJourney);
        }
        
        // Get the direction from this transform to the target transform
        Vector3 directionToTarget = pathPoints[currentPointIndex].position - transform.position;

        // Calculate the rotation only around the y-axis
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);

        // Lock the x rotation to the current rotation
        targetRotation.eulerAngles = new Vector3(transform.eulerAngles.x, targetRotation.eulerAngles.y, transform.eulerAngles.z);

        // Apply gradual rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
