using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake_Enemy_1 : MonoBehaviour, EnemyInterface
{
    private readonly float initHP = 20f;
    [SerializeField] private float currentHP;

    private Rigidbody myrigid;

    // hp Bar
    public Image hpBar;

    public float height = 1.7f;

    private void Start()
    {
        currentHP = initHP;
        myrigid = GetComponent<Rigidbody>();
    }


    public void Damage(int _damage)
    {
        if (currentHP <= 0)
        {
            Debug.Log("Enemy_Cake is Die!!");
            Destroy(gameObject);
            return;
        }
        else
        {
            currentHP -= _damage;
            DisPlayHP();
        }
    }

    private void DisPlayHP()
    {
        hpBar.fillAmount = currentHP / initHP;
    }
}
