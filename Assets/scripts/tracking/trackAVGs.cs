using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class trackAVGs : MonoBehaviour
{

    //This Script is responsible for reporting averages and data at the end of each trial as well as moving some data from the start up UI to the results csv
    public trackFacing proxemicsTracker;

    public GenerateExperiment experiment;

    public Session uxfSession;
    //Define items to be reported
    public string experimenter, subject, testType;

    public int trialSamples, globalSamples = 0;

    public float trialTotalGaze, globalTotalGaze;

    public float trialMeanGaze, globalMeanGaze;

    public float trialMedGaze, globalMedGaze;

    public float trialStdGaze, globalStdGaze;

    public List<float> trialGazeVals = new List<float>(), globalGazeVals = new List<float>();

    public float trialTotalDist, globalTotalDist;

    public float trialMeanDist, globalMeanDist;

    public float trialMedDist, globalMedDist;

    public float trialStdDist, globalStdDist;

    public List<float> trialDistVals = new List<float>(), globalDistVals = new List<float>();

    public void ResetTracker()
    {
      //Reset the tracking elements
      proxemicsTracker = gameObject.GetComponent<trackFacing>();

      //Set tje tpta;s fpr re[prtomg]
      trialSamples = proxemicsTracker.numSamples;
      
      trialTotalGaze = proxemicsTracker.totalGaze;
      trialTotalDist = proxemicsTracker.totalDistance;

      trialGazeVals = proxemicsTracker.gazeVals;
      trialDistVals = proxemicsTracker.distVals;

      globalGazeVals.AddRange(trialGazeVals);
      globalDistVals.AddRange(trialDistVals);
      
      globalTotalGaze += trialTotalGaze;
      globalTotalDist += trialTotalDist;

      globalSamples+=trialSamples;
      //Reset Traclers
      proxemicsTracker.numSamples = 0;
      proxemicsTracker.totalGaze = 0;
      proxemicsTracker.totalDistance = 0;
      proxemicsTracker.gazeVals = new List<float>();
      proxemicsTracker.distVals = new List<float>();
    }

    //Helpful stats functions
    public float GetMean(List<float> vals)
    {
      return vals.Sum() / vals.Count;
    }

    public float GetMedian(List<float> vals)
    {
      if (vals.Count == 0)
      {
          return 0;
      }
      
      vals.Sort();
      
      int middleIndex = vals.Count / 2;
      
      if (vals.Count % 2 == 0)
      {
          float median = (vals[middleIndex - 1] + vals[middleIndex]) / 2;
          return median;
      }
      else
      {
          return vals[middleIndex];
      }
    }
    
    public static float CalculateStandardDeviation(List<float> vals)
    {
        if (vals.Count == 0)
        {
            throw new ArgumentException("List cannot be empty.");
        }

        float mean = vals.Sum() / vals.Count;

        float sumOfSquaredDifferences = 0;

        foreach (float number in vals)
        {
            float difference = number - mean;
            sumOfSquaredDifferences += difference * difference;
        }

        float variance = sumOfSquaredDifferences / vals.Count;

        float standardDeviation = (float)Math.Sqrt(variance);

        return standardDeviation;
    }

    public void CalculateTrial()
    {
      //calculate the trial values
      trialMeanDist = GetMean(trialDistVals);
      trialMedDist = GetMedian(trialDistVals);
      trialStdDist = CalculateStandardDeviation(trialDistVals);

      trialMeanGaze = GetMean(trialGazeVals);
      trialMedGaze = GetMedian(trialGazeVals);
      trialStdGaze = CalculateStandardDeviation(trialGazeVals);
    }

    public void CalculateFinal()
    {
      //calculate globals
      globalMeanDist = GetMean(globalDistVals);
      globalMedDist = GetMedian(globalDistVals);
      globalStdDist = CalculateStandardDeviation(globalDistVals);

      globalMeanGaze = GetMean(globalGazeVals);
      globalMedGaze = GetMedian(globalGazeVals);
      globalStdGaze = CalculateStandardDeviation(globalGazeVals);
    }

    public void SaveAverage(Trial trial)
    {
      //Save average function (called at the end of each trial)
      ResetTracker();
      //calcualte the trial
      CalculateTrial();
      //handle special case for calculating the last trial
      if (trial == uxfSession.LastTrial)
      {
        
        CalculateFinal();
        experiment=GetComponent<GenerateExperiment>();
        foreach (Trial trials in experiment.myBlock.trials)
        {
          trials.result["global average distance"]=globalMeanDist;
          trials.result["global median distance"]=globalMedDist;
          trials.result["global standard deviation distance"]=globalStdDist;

          trials.result["global average gaze"]=globalMeanGaze;
          trials.result["global median gaze"]=globalMedGaze;
          trials.result["global standard deviation gaze"]=globalStdGaze;
        }

      }
      //report values
      trial.result["Experimenter Name"]=experimenter;
      trial.result["Subject Name"]=subject;
      trial.result["Test_Type"]=testType;
      trial.result["Subject ID"]=trial.result["ppid"];
      trial.result["Session"]="1";
      trial.result["File Path"]="test";
      trial.result["Task"]="Cliff Walk";
      
      trial.result["subject_average proxemics_location_0"]="Luke Attard";
      trial.result["subject_proxemics_location_0"]="Luke Attard";
      
      trial.result["trial average distance"]=trialMeanDist;
      trial.result["trial median distance"]=trialMedDist;
      trial.result["trial standard deviation distance"]=trialStdDist;
      trial.result["trial average gaze"]=trialMeanGaze;
      trial.result["trial median gaze"]=trialMedGaze;
      trial.result["trial standard deviation gaze"]=trialStdGaze;
      
      
      
    }
}
