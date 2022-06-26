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
    [SerializeField] private ParticleSystem hitEffect = null;


    public Transform cameraMom = null;
    private Animator hitAnim;

    private readonly int hashHit = Animator.StringToHash("isHit");

    private void Start()
    {
        mainCamTrn = Camera.main.transform;
        hitAnim = GetComponent<Animator>();

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Debug.DrawRay(mainCamTrn.transform.position, mainCamTrn.transform.forward * 100f, Color.red);

        if (Physics.Raycast(mainCamTrn.transform.position, mainCamTrn.transform.forward, out hitInfo, 100f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                hitAnim.SetTrigger(hashHit);
                //Debug.Log($"{hitInfo.collider.tag} АјАн!!");
                var _effect = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                if (hitInfo.collider.CompareTag(ConstantManager.TAG_ENEMY))
                {
                    //Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                    EnemyInterface enmey = hitInfo.collider.GetComponent<EnemyInterface>();

                    if (enmey != null)
                        enmey.Damage(1);
                }

            }
        }

    }

    private void FireBullet()
    {

    }
}
