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

    private void Start()
    {
        effect.gameObject.SetActive(false);
        playerCam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantManager.TAG_CANDY_CANE))
        {
            if (foodType == foodType.bad)
            {
                Debug.Log("BAD!!\n");
                TutorialManager.Instance.bad_item_count++;
            }

            else if (foodType == foodType.good)
            {
                Debug.Log("GOOD!!\n");
                TutorialManager.Instance.good_item_count++;
                TutorialManager.Instance.MoveWall();
            }

            ShowEffect();
            DoTweenCameraShaking(0.2f, 0.3f, 2);
            Invoke(nameof(DestroyObj), 0.7f);
        }
    }

    private void ShowEffect()
    {
        effect.gameObject.SetActive(true);
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
