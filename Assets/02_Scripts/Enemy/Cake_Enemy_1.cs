using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake_Enemy_1 : MonoBehaviour, EnemyInterface
{
    [SerializeField] private float hp = 50f;

    private Rigidbody myrigid;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
    }

    public void Damage(int _damage)
    {
        if (hp <= 0)
        {
            Debug.Log("Enemy_Cake is Die!!");
            Destroy(gameObject);
            return;
        }
        else
        {
            hp -= _damage;
        }
    }
}
