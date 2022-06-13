using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float moveSeed = 10f;

    private Rigidbody myrigid;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
        myrigid.AddForce(transform.forward * 1000f);

    }

    //private void Update()
    //{
    //    transform.Translate(Vector3.forward * moveSeed * Time.deltaTime);
    //}
}
