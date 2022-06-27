using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    [Header("--------Enemys_Obj--------")]
    public GameObject enemy1;

    private WaitForSeconds waits = new WaitForSeconds(3f);

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            CreateEnemy();

            yield return waits;
        }
    }

    private void CreateEnemy()
    {
        var idx = Random.Range(0, points.Count);

        var _enemy = Instantiate(enemy1, points[idx]);
        //Debug.Log($"enemy {points[idx]}위치에 생성!\n");
    }

}
