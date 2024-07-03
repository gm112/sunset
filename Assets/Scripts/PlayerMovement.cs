using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform orientation;

    [Header("Movement")]
    float moveSpeed = 6f;
    private float airMultiplier = .8f;
    float movementMultiplier = 1f;

    [Header("Sprinting")]
    float walkSpeed = 6f;
    float sprintSpeed = 15f;
    bool isSprinting = true;
    [SerializeField] float acceleration = 10f;

    [Header("Jumping")]
    float jumpForce = 24f;
    float jumpAmt = 2;
    float jumpCurrentAmt = 0;
    float gravmod = .2f;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    //[SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    //[Header("Drag")]
    float groundDrag = 8f;
    float airDrag = 3f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.2f;
    public bool isGrounded { get; private set; }

    Vector3 moveDirection;
    Vector3 slopeMoveDirection;

    Rigidbody rb;

    RaycastHit slopeHit;

    float dashVelocity;
    Vector3 dashVector = Vector3.zero;

    public PhysicMaterial physMat;
    public Transform dashTarget;
    public Transform cam;

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        MyInput();
        ControlDrag();
        ControlSpeed();

        if (Input.GetKeyDown(jumpKey) && jumpCurrentAmt+1f < jumpAmt)
        {
           
            jumpCurrentAmt = jumpCurrentAmt + 1;
            Debug.Log(jumpCurrentAmt);
            Jump();
        }
        if(isGrounded){
            jumpCurrentAmt = 0;
            gravmod = .8f;
        }

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);

        //Dash
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            rb.velocity = new Vector3(rb.velocity.x, .8f, rb.velocity.z);
            if(horizontalMovement == 0 && verticalMovement >0){
                
                //rb.AddForce(Camera.main.transform.forward * 30f, ForceMode.Impulse);
                //dashVelocity = 80f;
                dashVector = (dashTarget.position - cam.position)*3f;
                dashVelocity = 60f;

            }else{
                //rb.AddForce(moveDirection *30f,ForceMode.Impulse);
                dashVelocity = 60f;
                dashVector = Vector3.zero;
            }
            
        }
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        if(horizontalMovement == 0 && verticalMovement == 0){
            physMat.staticFriction = 10f;
            physMat.dynamicFriction = 10f;
        }else{
            physMat.staticFriction = 0f;
            physMat.dynamicFriction = 0f;
        }
    }

    void Jump()
    {
        // if (isGrounded)
        // {
            
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
             //
        // }
    }

    void ControlSpeed()
    {   
        if(Input.GetKeyDown(KeyCode.R)){
            isSprinting = !isSprinting;
        }
        if (isSprinting)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed+dashVelocity, acceleration * Time.deltaTime);
        }else{
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed+dashVelocity, acceleration * Time.deltaTime);
        }

    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer2();
        if(rb.velocity.y <-1f && !isGrounded){
               gravmod = gravmod + .001f;
            
        }
        
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y - .1f -gravmod,rb.velocity.z);
         rb.velocity = rb.velocity + dashVector;
        //Debug.Log(rb.velocity.x);
        dashVector = Vector3.Lerp(dashVector, Vector3.zero, .3f);
        if(dashVelocity > 0){
            dashVelocity = dashVelocity - 5f;
           // gravmod = gravmod - (dashVelocity/800f) + .06f;
        }
    }

    void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y - .2f, rb.velocity.z);
        }
    }

    void MovePlayer2(){
        Vector3 mov = moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier;
        rb.velocity = new Vector3(mov.x,rb.velocity.y,mov.z);
    }
}