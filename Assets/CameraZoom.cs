using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f; // Speed of zooming
    public float minZoom = 20f; // Minimum zoom limit (field of view or orthographic size)
    public float maxZoom = 60f; // Maximum zoom limit (field of view or orthographic size)

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Get scroll input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (cam.orthographic)
        {
            // Zoom for Orthographic Camera
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
        else
        {
            // Zoom for Perspective Camera
            cam.fieldOfView -= scroll * zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom);
        }
    }
}
