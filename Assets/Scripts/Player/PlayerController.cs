using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;
using UnityEngine.Rendering;
public class PlayerController : MonoBehaviour
{

    Vector2 direction;

    [Tooltip("Speed ​​at which the character moves. It is not affected by gravity or jumping.")]
    public float velocity = 5f;
    [Tooltip("Speed Multiplier ​​at which the character moves. It is not affected by gravity or jumping.")]
    public float velocityMulti = 1f;
    [Tooltip("This value is added to the speed value while the character is sprinting.")]
    public float sprintAdittion = 3.5f;
    [Tooltip("The higher the value, the higher the character will jump.")]
    public float jumpForce = 18f;
    [Tooltip("Stay in the air. The higher the value, the longer the character floats before falling.")]
    public float jumpTime = 0.85f;
    [Space]
    [Tooltip("Force that pulls the player down. Changing this value causes all movement, jumping and falling to be changed as well.")]
    public float gravity = 9.8f;

    float jumpElapsedTime = 0;

    // Player states
    bool isJumping = false;
    bool isSprinting = false;
    bool isCrouching = false;

    // Inputs
    float inputHorizontal;
    float inputVertical;
    bool inputJump;
    bool inputCrouch;
    bool inputSprint;


    PlayerReferences playerReferences;

    public enum PlayerInputSelect
    {
        Mobile,
        PC
    }

    public PlayerInputSelect playerInputSelect;

    NewPlayerInput playerInput;

    public FixedJoystick fixedJoystick;

    public float charSpeed;

    public bool isRunning;
    private void Awake()
    {
        playerInput = new NewPlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        Skill_MoveSpeedUp_Button.OnMoveSpeedUpPress += ChangeVelocityMulti;
    }

    private void OnDisable()
    {
        playerInput.Disable();
         Skill_MoveSpeedUp_Button.OnMoveSpeedUpPress -= ChangeVelocityMulti;
    }



    void Start()
    {

        playerReferences = GetComponent<PlayerReferences>();
        // Message informing the user that they forgot to add an playerReferences.animator
        if (playerReferences.animator == null)
            Debug.LogWarning("Hey buddy, you don't have the playerReferences.animator component in your player. Without it, the animations won't work.");
    }


    // Update is only being used here to identify keys and trigger animations
    void Update()
    {

        // // Input checkers
        // inputHorizontal = Input.GetAxis("Horizontal");
        // // Debug.Log(inputHorizontal);
        // inputVertical = Input.GetAxis("Vertical");



        // if (playerInputSelect == PlayerInputSelect.Mobile && fixedJoystick!= null)
        // {
        //     inputHorizontal = fixedJoystick.Horizontal;
        //     inputVertical = fixedJoystick.Vertical;
        // }
        // else if (playerInputSelect == PlayerInputSelect.PC)
        // {
        direction = playerInput.Player.Move.ReadValue<Vector2>();

        inputHorizontal = direction.x;
        inputVertical = direction.y;
        // }

        if (playerInput.Player.Jump.WasPerformedThisFrame())
        {
            Jump();
        }


        // inputHorizontal = fixedJoystick.Horizontal;
        // inputVertical = fixedJoystick.Vertical;
        //        Debug.Log(inputHorizontal);
        // inputJump = Input.GetAxis("Jump") == 1f;
        //inputSprint = Input.GetAxis("Fire3") == 1f;
        // Unfortunately GetAxis does not work with GetKeyDown, so inputs must be taken individually
        // inputCrouch = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.JoystickButton1);

        // Check if you pressed the crouch input key and change the player's state
        // if (inputCrouch)
        //     isCrouching = !isCrouching;

        // Run and Crouch animation
        // If dont have playerReferences.animator component, this block wont run
        if (playerReferences.cc.isGrounded && playerReferences.animator != null)
        {

            // Crouch
            // Note: The crouch animation does not shrink the character's collider
            //   playerReferences.animator.SetBool("crouch", isCrouching);

            // Run
            float minimumSpeed = 0.5f;
            charSpeed = playerReferences.cc.velocity.magnitude;
            playerReferences.animator.SetBool("run", playerReferences.cc.velocity.magnitude > minimumSpeed);

            // Sprint
            isSprinting = playerReferences.cc.velocity.magnitude > minimumSpeed && inputSprint;
            //playerReferences.animator.SetBool("sprint", isSprinting);

        }

        // Jump animation
        if (playerReferences.animator != null)
            playerReferences.animator.SetBool("air", playerReferences.cc.isGrounded == false);

        HeadHittingDetect();

    }


    // With the inputs and animations defined, FixedUpdate is responsible for applying movements and actions to the player
    private void FixedUpdate()
    {

        // Sprinting velocity boost or crounching desacelerate
        float velocityAdittion = 0;
        // Debug.Log("VD = " + velocityAdittion);
        if (isSprinting)
            velocityAdittion = sprintAdittion;
        // if (isCrouching)
        //     velocityAdittion = -(velocity * 0.50f); // -50% velocity

        // Direction movement
        float directionX = inputHorizontal * ((velocity * velocityMulti) + velocityAdittion) * Time.deltaTime;
        float directionZ = inputVertical * ((velocity * velocityMulti) + velocityAdittion) * Time.deltaTime;
        float directionY = 0;

        // Jump handler
        if (isJumping)
        {

            // Apply inertia and smoothness when climbing the jump
            // It is not necessary when descending, as gravity itself will gradually pulls
            directionY = Mathf.SmoothStep(jumpForce, jumpForce * 0.30f, jumpElapsedTime / jumpTime) * Time.deltaTime;

            // Jump timer
            jumpElapsedTime += Time.deltaTime;
            if (jumpElapsedTime >= jumpTime)
            {
                isJumping = false;
                jumpElapsedTime = 0;
            }
        }

        // Add gravity to Y axis
        directionY = directionY - gravity * Time.deltaTime;


        // --- Character rotation --- 

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Relate the front with the Z direction (depth) and right with X (lateral movement)
        forward = forward * directionZ;
        right = right * directionX;

        if (directionX != 0 || directionZ != 0)
        {
            float angle = Mathf.Atan2(forward.x + right.x, forward.z + right.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
        }

        // --- End rotation ---


        Vector3 verticalDirection = Vector3.up * directionY;
        Vector3 horizontalDirection = forward + right;

        Vector3 movement = verticalDirection + horizontalDirection;
        playerReferences.cc.Move(movement);

    }

    void Jump()
    {
        // Handle can jump or not
        if (playerReferences.cc.isGrounded)
        {
            isJumping = true;
            // Disable crounching when jumping
            //isCrouching = false; 
        }
    }

    void ChangeVelocityMulti(float value)
    {
        velocityMulti = value;
    }



    //This function makes the character end his jump if he hits his head on something
    void HeadHittingDetect()
    {
        float headHitDistance = 1.1f;
        Vector3 ccCenter = transform.TransformPoint(playerReferences.cc.center);
        float hitCalc = playerReferences.cc.height / 2f * headHitDistance;

        // Uncomment this line to see the Ray drawed in your characters head
        // Debug.DrawRay(ccCenter, Vector3.up * headHeight, Color.red);

        if (Physics.Raycast(ccCenter, Vector3.up, hitCalc))
        {
            jumpElapsedTime = 0;
            isJumping = false;
        }
    }

    // Get Input from Player
    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     direction = context.ReadValue<Vector2>();
    // }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Debug.Log("Pressed");
            Jump();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        inputSprint = context.ReadValue<float>() == 1f;
    }
}
