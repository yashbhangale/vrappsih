using UnityEngine;

public class CctvScript : MonoBehaviour
{
    public Camera overheadCamera;  // The overhead camera (active by default)
    public Camera fpsCamera;       // The FPS camera (initially inactive)
    public GameObject environment; // Reference to the environment object

    void Start()
    {
        // Ensure the overhead camera is enabled and FPS camera is disabled
        if (overheadCamera != null) overheadCamera.enabled = true;
        if (fpsCamera != null) fpsCamera.enabled = false;
    }

    void OnMouseDown()
    {
        // Check if the camera model is clicked
        SwitchToFPSCamera();
    }

    void SwitchToFPSCamera()
    {
        // Disable the overhead camera
        if (overheadCamera != null) overheadCamera.enabled = false;

        // Enable the FPS camera
        if (fpsCamera != null) fpsCamera.enabled = true;

        // Optionally, enable or highlight the environment if needed
        if (environment != null)
        {
            environment.SetActive(true);
        }

        // Lock the cursor for FPS view
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
