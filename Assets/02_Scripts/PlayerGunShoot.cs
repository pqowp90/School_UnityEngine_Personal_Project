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

        Debug.DrawRay(mainCamPos.position, mainCamPos.forward * 100f, Color.red);

        if (Physics.Raycast(mainCamPos.position, mainCamPos.forward, out hit, 100f))
        {
            GameObject bullet = Instantiate(BulletObj, mainCamPos.transform.position, mainCamPos.transform.rotation);
            Destroy(bullet, 2f);
        }
    }
}
