using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Cane : MonoBehaviour
{
    [SerializeField] private Animator hitAnim;
    [SerializeField] private ParticleSystem hitEffect = null;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShowHitAnimation();
        }
    }
    private void ShowHitAnimation()
    {
        hitAnim.SetTrigger("isHit");
        hitEffect.Play();
    }
}
