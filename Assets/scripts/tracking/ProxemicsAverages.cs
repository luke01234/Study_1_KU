using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UXF;
public class ProxemicsAverages : Tracker
{
    //script responsible for actually measuring the tracking of the users gaze
    public trackFacing proxemicsTracker;
    public override string MeasurementDescriptor => "Subject_Average_Proxemics";

    public override IEnumerable<string> CustomHeader => new string[] { "distance_Average", "gaze_Average" };
    public List<float> trialGazeVals = new List<float>(), trialDistVals = new List<float>();

    public float GetMean(List<float> vals)
    {
      return vals.Sum() / vals.Count;
    }

    void RecordAverage(UXFDataRow row)
    {
      proxemicsTracker = gameObject.GetComponent<trackFacing>();

      trialDistVals = proxemicsTracker.distVals;
      trialGazeVals = proxemicsTracker.gazeVals;

      row.Add(("distance_Average",GetMean(trialDistVals)));
      row.Add(("gaze_Average",GetMean(trialGazeVals)));
    }

    //Gets the current values of gaze and physical distance and adds them to a UXFDataRow.
    protected override UXFDataRow GetCurrentValues()
    {
      //Debug.Log("working");
      var row = new UXFDataRow();

        RecordAverage(row);
        
        
        return row;
    }
}
