using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;
public class trackFacing : Tracker
{
    //script responsible for actually measuring the tracking of the users gaze
    public Transform subject, agent;
    public float gazeScore = 0, physicalDistance = 0;

    public float totalGaze, totalDistance;

    public List<float> gazeVals = new List<float>(), distVals = new List<float>();

    private float FOV = 180;

    public int numSamples = 0;
    public override string MeasurementDescriptor => "Subject_Proxemics";

    public override IEnumerable<string> CustomHeader => new string[] { "distance", "gaze" };

    void RecordGaze(UXFDataRow row)
    {
      // Cast a ray from the object's position in the forward direction.
      // Modify the ray length or direction as needed for your specific use case.
      //Physics.Raycast(subject.transform.position, subject.transform.forward, out RaycastHit hit);
      
      // Get the position of the hit point.
      //Vector3 hitPosition = hit.point;

      //gazeScore = Vector3.Distance(hitPosition,agent.transform.position);

      // Calculate the direction vector from the subject to the agent.
      Vector3 agentLocation = agent.transform.position;
      Vector3 subjectLocation = subject.transform.position;
      Vector3 directionVector = agentLocation - subjectLocation;
      directionVector.Normalize();

      // Get the forward vector of the subject.
      Vector3 subjectForwardVector = subject.transform.forward;

      // Calculate the angle between the subject's forward vector and the direction vector.
      float angleBetween = Vector3.Angle(subjectForwardVector, directionVector);
      float halfFOV = FOV/2f;

      // Determine gaze score based on the angle between the vectors
      if (angleBetween >= halfFOV)
      {
        gazeScore = 0.0f;
      }
      else
      {
        gazeScore = 1.0f - (angleBetween/halfFOV);
      }

      // Add gaze score to the row and update related variables.
      row.Add(("gaze",gazeScore));
      totalGaze+=gazeScore;
      gazeVals.Add(gazeScore);
      numSamples++;
      //Debug.Log(gazeScore);
      
      //Debug.Log(numSamples);

    }

    //Records the physical distance between the subject and the agent
    void RecordPhys(UXFDataRow row)
    {
      physicalDistance = Vector3.Distance(subject.transform.position,agent.transform.position);
      row.Add(("distance",physicalDistance));
      totalDistance+=physicalDistance;
      distVals.Add(physicalDistance);
    }

    //Gets the current values of gaze and physical distance and adds them to a UXFDataRow.
    protected override UXFDataRow GetCurrentValues()
    {
      //Debug.Log("working");
      var row = new UXFDataRow();

        RecordPhys(row);
        RecordGaze(row);
        
        
        return row;
    }
}
