
using UnityEngine;

using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    [SerializeField]
    private InputActionReference runControl;
    [SerializeField]
    private InputActionReference runStopControl;


    [SerializeField]
    private float playerSpeed = 4.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 4.0f;
    



    //private CharacterController controller;

    public GameObject imp;
   
    private Animator animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public CharacterController controller;

    public Transform cameraMainTransform;

    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        runControl.action.Enable();
        runStopControl.action.Enable();

    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        runControl.action.Disable();
        runStopControl.action.Disable();

    }

   


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

       // cameraMainTransform = Camera.main.transform;

        animator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();

        Vector3 move = new Vector3(movement.x, 0, movement.y);

        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = .0f;

        controller.Move(move * Time.deltaTime * playerSpeed);

        



        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {

            animator.SetBool("Jump", true);
            animator.SetBool("Idle", false);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        if(movement != Vector2.zero)
        {

            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
        }
        

        if (runControl.action.triggered && groundedPlayer && movement != Vector2.zero)
        {

            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            playerSpeed = 12.0f;

            
        }

        if (runStopControl.action.triggered)

        {

            animator.SetBool("Run", false);
            animator.SetBool("Walking", true);
            playerSpeed = 4.0f;
            
        }

    }

   
}
