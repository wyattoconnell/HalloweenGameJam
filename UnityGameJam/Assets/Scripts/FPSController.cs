using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 2f;
    public float jumpForce = 5f;
    
    private Rigidbody rb;
    private Transform cameraPivot;
    public TextMeshProUGUI gameOverText;

    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraPivot = transform.Find("CameraPivot");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 velocity = move * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (moveZ < -20) {
            Debug.Log("Game Over");
            endGame();
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 20.1f);
    }

    private void endGame() {
    gameOverText.text = "Game Over"; 
    gameOverText.gameObject.SetActive(true); 
    }
}
