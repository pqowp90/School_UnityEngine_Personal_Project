using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private Transform cameraTrn = null;
    private Rigidbody myrigid;


    private PlayerData playerData;

    // Players
    public float turnSpeed = 80f;


    // Cameras
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private Quaternion playerTargetRotation;
    private Quaternion cameraTargetRotation;


    private void Awake()
    {
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");
        cameraTrn = Camera.main.transform;
    }

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();

        // Cameras
        playerTargetRotation = transform.localRotation;
        cameraTargetRotation = cameraTrn.transform.localRotation;
    }
    private void Update()
    {
        MoveAround();
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xInput = Input.GetAxis(ConstantManager.PM_HO);
        float zInput = Input.GetAxis(ConstantManager.PM_VER);

        Vector2 mouseInput = new Vector2(xInput, zInput);
        Vector3 desiredMove = (transform.forward * -1 * mouseInput.y) + (transform.right * -1 * mouseInput.x);
        transform.position += desiredMove * playerData.speed * Time.deltaTime;
    }

    private void MoveAround()
    {
        float mouseY = Input.GetAxis(ConstantManager.PM_MOX);
        float mouseX = Input.GetAxis(ConstantManager.PM_MOY);
        rotationX = cameraTrn.eulerAngles.y + mouseX * playerData.sensivity;

        rotationX = (rotationX > 180.0f) ? rotationX - 360 : rotationX;
        rotationY = rotationY + mouseY * playerData.sensivity;
        rotationY = Mathf.Clamp(rotationY, -45, 80);
        cameraTrn.eulerAngles = new Vector3(-rotationY, rotationX, 0);
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
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
