using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("-------Movement-------")]
    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDir = Vector3.zero;


    [Header("-------GroundCheck-------")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool isGrounded;


    private PlayerData playerData;
    private Rigidbody myrigid;
    public Transform orientation = null;

    [Header("-------Jump-------")]
    public float jumpCooldown;
    public float airMultiplier;

    private float jumpInput;
    private bool readyToJump = true;


    private void Awake()
    {
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");
    }

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
        myrigid.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();
        SpeedControl();

        if (isGrounded)
            myrigid.drag = groundDrag;
        else
            myrigid.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw(ConstantManager.PM_HO);
        verticalInput = Input.GetAxisRaw(ConstantManager.PM_VER);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        moveDir = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);

        if (isGrounded)
            myrigid.AddForce(moveDir.normalized * playerData.speed * 10f, ForceMode.Force);
        else
            myrigid.AddForce(moveDir.normalized * playerData.speed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(myrigid.velocity.x, 0f, myrigid.velocity.z);

        if (flatVel.magnitude > playerData.speed)
        {
            Vector3 limitedVel = flatVel.normalized * playerData.speed;
            myrigid.velocity = new Vector3(limitedVel.x, myrigid.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        readyToJump = false;

        //myrigid.velocity = new Vector3(myrigid.velocity.x, 0f, myrigid.velocity.y);
        myrigid.AddForce(transform.up * playerData.jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        if (readyToJump) return;
        readyToJump = true;
    }
}
