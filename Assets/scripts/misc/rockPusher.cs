using UnityEngine;

public class rockPusher : MonoBehaviour
{
    //script to make the rocks get pushed off the path and down the mountain valley
    //this script is kind of redundant after the changes to the rockslide
    public Transform targetTransform;
    public float pushForce = 10f;

    private void OnTriggerStay(Collider other)
    {
      //when rocks are in this trigger, push them towards a target
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        
        if (rb != null && other.gameObject.layer == LayerMask.NameToLayer("falling rock"))
        {
            Vector3 pushDirection = (targetTransform.position - other.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce *Time.deltaTime, ForceMode.Impulse);
        }
    }
}