using UnityEngine;

public class lookAtTarget : MonoBehaviour
{   
    //script to make the agent look at the player 
    public Transform targetTransform;
    public float rotationSpeed = 2f;

    private void Update()
    {
        if (targetTransform != null)
        {
            // Calculate the direction to the target
            Vector3 targetDirection = targetTransform.position - transform.position;
            targetDirection.y = 0f; // (Optional) Uncomment to ignore rotation along the Y-axis

            // Rotate the game object towards the target gradually
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}