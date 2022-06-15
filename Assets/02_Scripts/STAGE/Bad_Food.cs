using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_Food : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BAD!!\n");

            Destroy(gameObject);
        }
    }


    public void EatItem()
    {

    }
}
