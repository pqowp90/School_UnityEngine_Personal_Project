using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform target = null;    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag(ConstantManager.TAG_PLAYER).GetComponent<Transform>();
    }

    private void Update()
    {

    }
}
