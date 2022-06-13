using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunShoot : MonoBehaviour
{
    private Transform mainCamPos = null;
    public Transform BulletPos = null;
    public GameObject BulletObj = null;

    private void Start()
    {
        mainCamPos = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckRayCastHitPosition();
        }
    }

    private void CheckRayCastHitPosition()
    {
        RaycastHit hit;

        Debug.DrawRay(mainCamPos.transform.position, mainCamPos.transform.forward * 100f, Color.red);

        if (Physics.Raycast(mainCamPos.transform.position, mainCamPos.transform.forward, out hit, 100f))
        {
            if (hit.collider.CompareTag("ENEMY"))
            {
                Debug.Log("¶¼¹ÌÁö");
            }

            //GameObject bullet = Instantiate(BulletObj, mainCamPos.transform.position, mainCamPos.transform.rotation);
            //Destroy(bullet, 2f);
        }
    }
}
