using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera fpsCamera; // Assign your FPS camera here.
    public Camera overheadCamera; // Optional: Assign an overhead camera for NavMesh navigation.
    private NavMeshAgent navMeshAgent;
    private CharacterController characterController;
    private bool isFPSMode = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();

        if (fpsCamera != null) fpsCamera.enabled = false; // FPS mode camera starts disabled.
        if (overheadCamera != null) overheadCamera.enabled = true; // Overhead camera starts enabled.
    }

    void Update()
    {
        // Check for mouse click to toggle modes.
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    ToggleMode();
                }
            }
        }

        // Handle FPS controls when in FPS mode.
        if (isFPSMode)
        {
            HandleFPSControls();
        }
    }

    void ToggleMode()
    {
        isFPSMode = !isFPSMode;

        if (isFPSMode)
        {
            navMeshAgent.enabled = false;
            characterController.enabled = true;
            if (fpsCamera != null) fpsCamera.enabled = true;
            if (overheadCamera != null) overheadCamera.enabled = false;
        }
        else
        {
            navMeshAgent.enabled = true;
            characterController.enabled = false;
            if (fpsCamera != null) fpsCamera.enabled = false;
            if (overheadCamera != null) overheadCamera.enabled = true;
        }
    }

    void HandleFPSControls()
    {
        float moveSpeed = 5f;
        float rotationSpeed = 200f;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        characterController.Move(move * moveSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
