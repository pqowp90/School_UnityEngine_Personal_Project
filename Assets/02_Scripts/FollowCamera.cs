using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float detailX = 5.0f;
    public float detailY = 5.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void LateUpdate()
    {
        FirstCamera();
    }
    void FirstCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX = transform.eulerAngles.y + mouseX * detailX;

        rotationX = (rotationX > 180.0f) ? rotationX - 360 : rotationX;
        rotationY = rotationY + mouseY * detailY;
        rotationY = Mathf.Clamp(rotationY, -45, 80);
        transform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
