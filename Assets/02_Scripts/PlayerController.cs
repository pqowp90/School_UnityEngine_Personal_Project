using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerData playerData;

    private Rigidbody myrigid;
    private Transform playerTrn = null;


    public float turnSpeed = 80f;
    private void Awake()
    {
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");
        playerTrn = GetComponent<Transform>();
    }

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xInput = Input.GetAxis(ConstantManager.PM_HO);
        float zInput = Input.GetAxis(ConstantManager.PM_VER);
        float xrInput = Input.GetAxis(ConstantManager.PM_MOUSEX);
        float yrInput = Input.GetAxis(ConstantManager.PM_MOUSEY);

        Vector3 moveDir = (Vector3.right * xInput) + (Vector3.forward * zInput);
        moveDir.Normalize();

        Vector3 rotateDir = (Vector3.up * xrInput);

        playerTrn.Translate(moveDir * playerData.speed * Time.deltaTime);
        //playerTrn.Rotate(rotateDir * turnSpeed * Time.deltaTime);
    }

    private void JumpPlayer()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ConstantManager.TAG_FLOOR))
        {

        }
    }
}
