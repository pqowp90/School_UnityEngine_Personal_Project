using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float moveSeed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSeed * Time.deltaTime);
    }
}
