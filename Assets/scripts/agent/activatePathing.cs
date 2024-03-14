using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatePathing : MonoBehaviour
{ 
    //Script in charge of activating the path movement of the agent when the user walks into a certain trigger
    public GameObject agent;
    private pathmove pathScript;

    private void Awake()
    {
      pathScript = agent.GetComponent<pathmove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object is on the subject layer
        if (other.gameObject.layer == LayerMask.NameToLayer("Subject"))
        {
          pathScript.enabled = true;
        }
    }
}