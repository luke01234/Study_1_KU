using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UXF;

public class endTrialTrigger : MonoBehaviour
{
    //script to end the current trial when a trigger is entered
    public Session session;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Subject"))
        {
        {
           session.GetTrial().End();
           enabled=false;
           GetComponent<BoxCollider>().enabled=false;
           //gameObject.SetActive(false);
        }
        }
    }

}
