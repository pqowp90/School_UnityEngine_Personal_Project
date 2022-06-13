using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake_Enemy_1 : MonoBehaviour
{
    [SerializeField] private float hp = 50f;

    private Rigidbody myrigid;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ConstantManager.TAG_BULLET))
        {
            Debug.Log("ÃÑ¾ËÂ»");
            Destroy(collision.gameObject);

            EnemyDamaged();
        }
    }

    private void EnemyDamaged()
    {
        if (hp <= 0)
        {
            Debug.Log("Enemy_Cake is Die!!");
            Destroy(gameObject);
            return;
        }
        else
        {
            --hp;
        }
    }
}
