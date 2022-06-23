using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Tomato : MonoBehaviour, Item_InterFace
{
    public ParticleSystem effect = null;

    public void GetItem()
    {
        Invoke(nameof(PlayerObjFalse), 0.5f);
        effect.gameObject.SetActive(true);
    }

    private void PlayerObjFalse()
    {
        Destroy(gameObject);
    }
}
