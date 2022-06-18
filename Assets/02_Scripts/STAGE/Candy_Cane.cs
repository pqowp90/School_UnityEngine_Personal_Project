using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Cane : MonoBehaviour
{
    [SerializeField] private Animator hitAnim;
    [SerializeField] private ParticleSystem hitEffect = null;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (TutorialManager.Instance.state == Tutorial_State.isStory) return;
        if (Input.GetMouseButtonDown(0))
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
