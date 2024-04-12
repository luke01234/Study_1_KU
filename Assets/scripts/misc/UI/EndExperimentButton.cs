using UnityEngine;
using UXF;

public class EndExperimentButton : MonoBehaviour
{
    // Reference to the UXF session
    private Session session;

    void Start()
    {
        // Get reference to the UXF session component
        session = FindObjectOfType<Session>();
        
        if (session == null)
        {
            Debug.LogError("No UXF Session found in the scene.");
        }
    }

    // Method to end the experiment
    public void EndExperiment()
    {
        if (session != null)
        {
            session.End();
            Debug.Log("Experiment Ended.");
        }
        else
        {
            Debug.LogError("No UXF Session found. Cannot end experiment.");
        }
    }
}
