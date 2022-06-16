using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum foodType
{
    bad,
    good,
}

public class Tuto_Food_Item : MonoBehaviour
{
    public ParticleSystem effect = null;

    public foodType foodType;

    private void Start()
    {
        effect.gameObject.SetActive(false);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (foodType == foodType.bad)
            {
                Debug.Log("BAD!!\n");
            }

            else if (foodType == foodType.good)
            {
                Debug.Log("GOOD!!\n");
                TutorialManager.Instance.MoveWall();
            }

            ShowEffect();
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
}
