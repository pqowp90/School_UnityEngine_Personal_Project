using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet = null;

    private WaitForSeconds waits = new WaitForSeconds(1f);
    private WaitForSeconds waits_dely = new WaitForSeconds(6f);

    private void Start()
    {
        StartCoroutine(ReadyShoot());
    }
    private IEnumerator ReadyShoot()
    {
        while (true)
        {
            //yield return waits_dely;
            for (int i = 0; i < 5; i++)
            {
                StartAttack();

                yield return waits;
            }
        }
    }

    private void StartAttack()
    {
        var _obj = Instantiate(bullet, transform.position, Quaternion.LookRotation(Camera.main.transform.position));
        _obj.transform.SetParent(null);

        Destroy(_obj, 4f);
    }
}
