using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody = null;

    private PlayerData playerData;

    private float xRotation = 0f;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");
    }

    private void Update()
    {
        // if Tutorial && Storying // don't look around 
        //if (TutorialManager.Instance.state == Tutorial_State.isStory) return;
        if (GameManager.Instance.tutoState == Tutorial_State.isStory) return;

        float mouseX = Input.GetAxis(ConstantManager.PM_MOX) * playerData.sensivity;
        float mouseY = Input.GetAxis(ConstantManager.PM_MOY) * playerData.sensivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
