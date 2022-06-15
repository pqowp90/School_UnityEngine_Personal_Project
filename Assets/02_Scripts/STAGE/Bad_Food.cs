using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_Food : MonoBehaviour/*, Tuto_Item_Interface*/
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BAD!!\n");

            Destroy(gameObject);
        }
    }


    public void EatItem()
    {

    }
}
