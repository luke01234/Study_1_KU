using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float sensitivity = 5.0f;
    public float maxYAngle = 80.0f;
    public float moveSpeed = 5.0f;
    public float sprintSpeedMultiplier = 2.0f;
    public float verticalSpeed = 3.0f;

    public bool freeCamEnabled = false;
    private float rotationX = 0;

    void Start()
    {
        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableCam()
    {
      freeCamEnabled = true;
    }

    void Update()
    {
        if (freeCamEnabled)
        {
            // Rotation
            float rotationY = Input.GetAxis("Mouse X") * sensitivity;
            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);

            transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + rotationY, 0);

            // Movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

            // Sprint
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * sprintSpeedMultiplier : moveSpeed;

            moveDirection = transform.TransformDirection(moveDirection);
            transform.position += moveDirection * currentSpeed * Time.deltaTime;

            // Vertical movement
            float upDownMovement = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                upDownMovement = verticalSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                upDownMovement = -verticalSpeed;
            }

            Vector3 verticalMovement = transform.up * upDownMovement;
            transform.position += verticalMovement * Time.deltaTime;

            // Escape key
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CancelFreeCam();
            }
        }
    }

    void CancelFreeCam()
    {
        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;

        // Disable this script
        freeCamEnabled = false;

        // Implement any additional cancellation logic here
        Debug.Log("FreeCam cancelled");
    }
}
