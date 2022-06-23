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
                Debug.Log($"{hitInfo.collider.tag} 공격!!");
                var _effect = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                // 총알이이상한데로날라가여 ;;;;;;;;
                //var _bullet = Instantiate(bulletObj, bulletTrn.position, hitInfo.transform.rotation);
                //var _bullet = Instantiate(bulletObj, bulletTrn.position, Quaternion.LookRotation(hitInfo.point));
                //var _bullet = Instantiate(bulletObj, bulletTrn.transform.position, Quaternion.LookRotation(hitInfo.normal));

                //float angle = Mathf.Atan2(v3.z, v3.x) * Mathf.Rad2Deg;
                //Quaternion angleQ = Quaternion.Euler(new Vector3(0, -angle, 0));

                // ChanHee
                //Vector3 v3 = hitInfo.transform.position - bulletTrn.transform.position;
                //Quaternion angleQ = Quaternion.LookRotation(v3);
                //var _bullet = Instantiate(bulletObj, bulletTrn.transform.position, angleQ);


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
