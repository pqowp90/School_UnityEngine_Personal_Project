using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Good_Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("GOOD!!\n");

            Destroy(gameObject);
        }
    }

    public void EatItem()
    {

    }
}
