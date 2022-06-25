using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowEnemy : MonoBehaviour
{
    public Transform taget = null;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (GameManager.Instance.tutoState == Tutorial_State.isStory) return;
        agent.SetDestination(taget.position);
    }
}
