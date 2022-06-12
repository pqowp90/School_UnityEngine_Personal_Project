using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunShoot : MonoBehaviour
{
    public Transform a;
    public Transform BulletPos = null;
    public GameObject BulletObj = null;

    private void Update()
    {
        CheckRayCastHitPosition();
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    private void CheckRayCastHitPosition()
    {
        RaycastHit hit;

        Debug.DrawRay(a.position, transform.forward * 100f, Color.red);

        if(Physics.Raycast(a.position, transform.forward,out hit,100f))
        {
            Debug.Log(hit.transform.position);
        }
    }
    
    private void FireBullet()
    {
        GameObject bullet = Instantiate(BulletObj, transform.position, transform.rotation);
    }
}
