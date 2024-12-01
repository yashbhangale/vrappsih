using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Camera playerCamera;  // Reference to the player's camera
    public float mouseSensitivity = 100f;  // Mouse sensitivity for looking around
    public float clampAngle = 80f; // The maximum angle you can rotate vertically (pitch)

    private float rotationX = 0f; // Current vertical rotation (pitch)

    void Update()
    {
        HandleMouseLook();
    }

    void HandleMouseLook()
    {
        // Get the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Update the vertical rotation (pitch)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle); // Limit vertical rotation

        // Apply vertical and horizontal rotations
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);  // Vertical rotation (pitch)
        transform.Rotate(Vector3.up * mouseX);  // Horizontal rotation (yaw)
    }
}
