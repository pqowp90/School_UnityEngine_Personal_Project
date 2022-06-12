using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGun : MonoBehaviour
{
    public Transform followTarget = null;

    private void Update()
    {
        transform.position = followTarget.position;
    }
}
