using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropRockTriggerOnSubject : MonoBehaviour
{
    //script to drop rocks when the subject moves through a trigger

    public GameObject child;
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger");
        if (other.gameObject.layer == LayerMask.NameToLayer("Subject"))
        {
        {
            if (child != null) { child.SetActive(true); }
        }
        }
    }
}