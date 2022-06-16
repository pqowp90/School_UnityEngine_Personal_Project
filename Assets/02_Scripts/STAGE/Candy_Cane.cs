using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy_Cane : MonoBehaviour
{
    private Quaternion hitCaneRot;

    private void Start()
    {
        hitCaneRot = Quaternion.Euler(60f, -60f, -6.8f);
        Debug.Log(hitCaneRot);
    }
}
