using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;

public class Player : MonoBehaviour
{
    PlayerInput PlayerInput;
    private Rigidbody2D playerRigidBody;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Camera mainCam;

    private bool controllerToggle = false;

    private Vector2 mousePosition;
    private float horizontal;
    private float playerSpeed = 8f;
    private float jump = 10f;


    private void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.Player.Move.performed += Move;
        PlayerInput.Player.Move.canceled += Move;
        PlayerInput.Player.Jump.performed += Jump;
        PlayerInput.Player.Jump.canceled += Jump;
        PlayerInput.Player.ControlMode.started += ControlModeStart;
        // PlayerInput.Player.ControlMode.performed += ControlMode;
        PlayerInput.Player.ControlMode.canceled += ControlModeCanceled;
    }

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!controllerToggle)
        {
            playerRigidBody.velocity = new Vector2(horizontal * playerSpeed, playerRigidBody.velocity.y);
        }
        else
        {
            transform.position = mousePosition;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
        }
        if (context.canceled && playerRigidBody.velocity.y > 0f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y * 0.5f);
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    void ControlModeStart(InputAction.CallbackContext context)
    {
        SetMousePosition(transform.position);
        controllerToggle = true;
    }

    void ControlMode(InputAction.CallbackContext context)
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    void ControlModeCanceled(InputAction.CallbackContext context)
    {
        controllerToggle = false;
    }


    private void SetMousePosition(Vector3 worldPosition)
    {
        Vector3 screenPoint = mainCam.WorldToScreenPoint(worldPosition);
        Mouse.current.WarpCursorPosition(screenPoint);
    }
    private void OnEnable()
    {
        PlayerInput.Player.Enable();
    }
    private void OnDisable()
    {
        PlayerInput.Player.Disable();
    }
}
