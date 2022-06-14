using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("------GunInfo------")]
    [SerializeField] public Transform bulletTrn = null;
    [SerializeField] public GameObject bulletObj = null;

    private Transform mainCamTrn = null;
    RaycastHit hitInfo;

    [Header("------GunEffect------")]
    [SerializeField] private GameObject hitEffect = null;

    private void Start()
    {
        mainCamTrn = Camera.main.transform;


    }

    private void Update()
    {
        Debug.DrawRay(bulletTrn.transform.position, mainCamTrn.transform.forward * 100f, Color.magenta);
        if (Physics.Raycast(bulletTrn.transform.position, mainCamTrn.transform.forward, out hitInfo, 100f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"{hitInfo.collider.tag} АјАн!!");

                if (hitInfo.collider.CompareTag("ENEMY"))
                {
                    Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                    EnemyInterface enmey = hitInfo.collider.GetComponent<EnemyInterface>();

                    if (enmey != null)
                        enmey.Damage(1);
                }

            }
        }

    }
}
