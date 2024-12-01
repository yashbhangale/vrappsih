using UnityEngine;
using UnityEngine.UI;

public class WorkerController : MonoBehaviour
{
    public Camera overheadCamera; // Main overhead camera
    public Camera fpsCamera;      // FPS camera attached to the worker
    public Button fpsButton;      // UI Button to go to FPS mode
    public Button backButton;     // UI Button to go back to overhead camera

    private CharacterController characterController;

    private bool isFPSMode = false;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float moveSpeed = 5f;     // Player movement speed
    public float jumpHeight = 1.5f;  // Jump height
    public float gravity = -9.81f;   // Gravity value

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (fpsCamera != null) fpsCamera.enabled = false;
        if (overheadCamera != null) overheadCamera.enabled = true;

        // Set up buttons
        if (fpsButton != null)
        {
            fpsButton.gameObject.SetActive(true);
            fpsButton.onClick.AddListener(SwitchToFPSView);
        }
        if (backButton != null)
        {
            backButton.gameObject.SetActive(false);
            backButton.onClick.AddListener(SwitchToOverheadView);
        }
    }

    void Update()
    {
        if (isFPSMode)
        {
            HandleFPSControls();
        }
    }

    void SwitchToFPSView()
    {
        isFPSMode = true;

        if (fpsCamera != null) fpsCamera.enabled = true;
        if (overheadCamera != null) overheadCamera.enabled = false;

        if (fpsButton != null) fpsButton.gameObject.SetActive(false);
        if (backButton != null) backButton.gameObject.SetActive(true);
    }

    void SwitchToOverheadView()
    {
        isFPSMode = false;

        if (fpsCamera != null) fpsCamera.enabled = false;
        if (overheadCamera != null) overheadCamera.enabled = true;

        if (fpsButton != null) fpsButton.gameObject.SetActive(true);
        if (backButton != null) backButton.gameObject.SetActive(false);
    }

    void HandleFPSControls()
    {
        // Check if the player is grounded
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Move the player
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;

        // Move the player vertically (for jumping and gravity)
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
