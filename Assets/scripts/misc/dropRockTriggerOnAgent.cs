using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropRockTriggerOnAgent : MonoBehaviour
{
  //script to drop rocks when the agent moves through a trigger
    public GameObject child;
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger");
        if (other.gameObject.layer == LayerMask.NameToLayer("agent"))
        {
        {
            if (child != null) { child.SetActive(true); }
        }
        }
    }
}