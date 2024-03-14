using UnityEngine;

public class playermovevr : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;
    public Camera playerCamera;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Lock cursor to center of screen
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = playerCamera.transform.forward;
        Vector3 cameraRight = playerCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal) * movementSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Player rotation
        //float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        //transform.Rotate(Vector3.up * mouseX);
    }
}
