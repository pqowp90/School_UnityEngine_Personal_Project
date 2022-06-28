using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private float speed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerData = Resources.Load<PlayerData>("SO/" + "PlayerData");

        speed = playerData.speed;
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
        RunPlayer();

        // if Tutorial && Storying // don't move Player
        //if (TutorialManager.Instance.state == Tutorial_State.isStory) return;
        if (GameManager.Instance.tutoState == Tutorial_State.isStory) return;
        if (GameManager.Instance.state == PlayState.isSetting) return;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown(ConstantManager.PM_JP) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerData.jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void RunPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = playerData.runspeed;
        else
            speed = playerData.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantManager.TAG_ITEM))
        {
            Item_InterFace item = other.GetComponent<Item_InterFace>();

            if (item != null)
                item.GetItem();
        }
        if (other.CompareTag(ConstantManager.TAG_ENEMY) || other.CompareTag(ConstantManager.TAG_ENEMY_BULLET)   )
        {
            GameManager.Instance.SettingPlayerLife(1f);
            UIManager.Instance.UpdateUI();

            DoTweenCameraShaking(0.2f, 0.3f, 2);
            Debug.Log("life low");
        }
    }

    private void DoTweenCameraShaking(float _dur, float _str, int _vibro)
    {
        Camera.main.DOShakePosition(_dur, _str, _vibro);
    }
}
