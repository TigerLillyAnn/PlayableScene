using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    private Camera playerCamera;

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

        transform.Rotate(Vector3.up * mouseX * lookSpeed); // Rotate player horizontally
        playerCamera.transform.Rotate(Vector3.left * mouseY * lookSpeed); // Rotate camera vertically
    }
}
