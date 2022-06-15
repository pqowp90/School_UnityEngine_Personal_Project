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
            Destroy(gameObject);
        }
    }

    private void ShowEffect()
    {
        Debug.Log("qwe");
    }
}
