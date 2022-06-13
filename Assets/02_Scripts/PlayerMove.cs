using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private PlayerData playerData;

    private float gravity = -9.8f;
    public Transform groundCheck = null;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");
    }


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis(ConstantManager.PM_HO);
        float z = Input.GetAxis(ConstantManager.PM_VER);

        Vector3 move = (transform.right * x) + (transform.forward * z);

        controller.Move(move * playerData.speed * Time.deltaTime);

        if (Input.GetButtonDown(ConstantManager.PM_JP) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerData.jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}