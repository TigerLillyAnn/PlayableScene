using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public Vector3 cameraOffset = new Vector3(0f, 2f, 0f); // Offset to position the camera above the player
    private Camera playerCamera;
    private float rotationX = 0f; // Store vertical rotation for clamping

    private void Start()
    {
        playerCamera = Camera.main; // Find the main camera
    }

    private void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    // Function to control the player's movement
    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * horizontal + transform.forward * vertical).normalized;

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    // Function to make the player look around based on mouse movement
    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX * lookSpeed);

        // Rotate camera vertically with clamping
        rotationX -= mouseY * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f); // Clamping the vertical rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Ensure the camera stays at the fixed offset above the player
        playerCamera.transform.position = transform.position + cameraOffset;
    }
}
