using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    Controls controls;
    CharacterController characterController;

    //variables for player input values
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    Vector3 appliedMovement;

    bool isMovementPressed;

    bool isRunPressed;


    public float moveSpeed = 500.0f;
    float rotationFactorPerFrame = 15f;
    float runMultiplier = 3.0f;

    float gravity = -9.8f;
    float groundedGravity = -0.5f;

    //Jumping

    bool isJumpPressed = false;
    float initialJumpVelocity;
    float maxJumpHeight = 2.0f;
    float maxJumpTime = 0.5f;
    bool isJumping = false;


    [SerializeField]
    private Transform cameraTransform;






    private void Awake()
    {
        controls = new Controls();
        characterController = GetComponent<CharacterController>();

        controls.Gameplay.Move.started += OnMovementInput;


        controls.Gameplay.Move.canceled += OnMovementInput;

        controls.Gameplay.Move.performed += OnMovementInput;


        controls.Gameplay.Run.started += onRun;
        controls.Gameplay.Run.canceled += onRun;


        controls.Gameplay.Jump.started += onJump;
        controls.Gameplay.Jump.canceled += onJump;

        setupJumpVariables();

    }

    void setupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        float gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }


    void handleJump()
    {
        if (!isJumping && characterController.isGrounded && isJumpPressed)
        {
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
            appliedMovement.y = initialJumpVelocity;
        }
        else if (!isJumpPressed && isJumping && characterController.isGrounded)
        {
            isJumping = false;
        }
    }



    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }



    void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }



    void handleRotation()
    {
        Vector3 positionToLookAt;
        // the change in rotation
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;


        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }





    }


    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * moveSpeed;
        currentMovement.z = currentMovementInput.y * moveSpeed;

        currentRunMovement.x = currentMovementInput.x * moveSpeed * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * moveSpeed * runMultiplier;

        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;


    }



    void handleGravity()
    {

        bool isFalling = currentMovement.y <= 0.0f || !isJumpPressed;
        float fallMultiplier = 2.0f;

        if (characterController.isGrounded)
        {

            currentMovement.y = groundedGravity;
            appliedMovement.y = groundedGravity;
        }
        else if (isFalling)
        {
            float previousYVelocity = currentMovement.y;
            currentMovement.y = currentMovement.y + (gravity * fallMultiplier * Time.deltaTime);
            appliedMovement.y = Mathf.Max((previousYVelocity + currentMovement.y) * .5f -20.0f);
            
        }
        
        
        else
        {
            float previousYVelocity = currentMovement.y;
            currentMovement.y = currentMovement.y + (gravity * Time.deltaTime);
            appliedMovement.y = (previousYVelocity + currentMovement.y) * .5f;
            
        }
    }



        // Update is called once per frame
        void Update()
        {

        handleRotation();


        if (isRunPressed)
        {
            appliedMovement.x = currentRunMovement.x;
            appliedMovement.z = currentRunMovement.z;
        }
        else
        {
            appliedMovement.x = currentMovement.x;
            appliedMovement.z = currentMovement.z;
        }

        characterController.Move(appliedMovement * Time.deltaTime);


        handleGravity();
        handleJump();


      



        }

        void OnEnable()
        {
            controls.Gameplay.Enable();
        }

        void OnDisable()
        {
            controls.Gameplay.Disable();
        }

    }



