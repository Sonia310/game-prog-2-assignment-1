using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public bool isDoubleJump = false;
    public float mouseSensitivity = 2f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
    
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
       UpdateRotation();
       ProcessMovement();
    }

    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivity, 0, Space.Self);
 
    }
    
   void ProcessMovement()
    { 
        float speed = GetMovementSpeed();
 
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
 
        cameraForward.y = 0;
        cameraRight.y = 0;
 
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));
 
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;
 
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump"))
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else
            {
                gravity.y = -1.0f;
            }
        }
        else if (!groundedPlayer && isDoubleJump && Input.GetButtonDown("Jump"))
        {
            gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            isDoubleJump = false;
        }
        else
        {
            gravity.y += gravityValue * Time.deltaTime;
        }
        
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

    public void setDoubleJump(bool value)
    {
        isDoubleJump = value;
    }
}