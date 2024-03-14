using UnityEngine;

public class freeCam : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 3.0f;

    void Update()
    {
        // Translation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float forwardInput = Input.GetAxis("Forward");

        Vector3 movement = new Vector3(horizontalInput, forwardInput, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
        transform.eulerAngles += rotation;
    }
}
