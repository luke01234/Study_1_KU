using UnityEngine;

public class freeCam : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 3.0f;

    void Update()
    {
        // this is a script to allow for freecam movement of the tester, this uses a very old version of unity movement, however it gets the job done
        //controls are W A S D for left and right movement, and space for upward, control for downward movement
        // Translation handler
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float forwardInput = Input.GetAxis("Forward");

        Vector3 movement = new Vector3(horizontalInput, forwardInput, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement); //move the object according to the inputs

        // Rotation handler
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotationSpeed;
        transform.eulerAngles += rotation;
    }
}
