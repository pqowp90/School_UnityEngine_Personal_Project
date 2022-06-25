using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum foodType
{
    bad,
    good,
}

public class Tuto_Food_Item : MonoBehaviour
{
    public ParticleSystem effect = null;

    public foodType foodType;
    private Camera playerCam;

    private int life = 2;

    private void Start()
    {
        playerCam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantManager.TAG_CANDY_CANE))
        {
            life--;
            ShowEffect();
            DoTweenCameraShaking(0.2f, 0.3f, 2);

            if (life <= 0)
            {
                TutorialManager.Instance.good_item_count++;
                if (TutorialManager.Instance.good_item_count % 2 == 0)
                {
                    var _speed = 6f - 1.4f;
                    var _runspeed = 7.5f - 1.4f;
                    var _jumpForce = 1f - 0.2f;

                    TutorialManager.Instance.SetPlayerValue(_speed, _runspeed, _jumpForce);
                }

                TutorialManager.Instance.ItemTextUpdate();
                Invoke(nameof(DestroyObj), 0.7f);
            }
        }
    }

    private void ShowEffect()
    {
        effect.Play();
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }

    private void DoTweenCameraShaking(float _dur, float _str, int _vibro)
    {
        playerCam.DOShakePosition(_dur, _str, _vibro);
    }
}
