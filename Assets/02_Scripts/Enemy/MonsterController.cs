using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Attack,
        Trace,
        Die,
        PlayerDie,
    }

    public State state = State.Idle;

    private bool isDie = false;

    public float traceDist = 10f;

    public float attackDist = 2f;


    // Components Cashing
    private Transform monsterTrn = null;
    private Transform targetTrn = null;
    private Animator animator = null;
    private NavMeshAgent agent = null;

    // Get HashTable Values
    private readonly int hashTrace = Animator.StringToHash("isTrace");
    private readonly int hashAttack = Animator.StringToHash("isAttack");
    private readonly int hashDie = Animator.StringToHash("Die");
    private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");

    // Monster initial Life_Value
    private readonly int iniHP = 50;
    private int currHP;

    private void Start()
    {
        // Set Monster HP
        currHP = iniHP;

        monsterTrn = GetComponent<Transform>();
        targetTrn = GameObject.FindWithTag("PLATER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        state = State.Idle;
        currHP = iniHP;

        isDie = false;

        StartCoroutine(CheckMonsterState());
    }

    private IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ConstantManager.TAG_BULLET))
        {
            Destroy(collision.gameObject);

            currHP -= 10;

            if (currHP <= 0)
            {
                state = State.Die;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (state == State.Trace)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(monsterTrn.position, traceDist);
        }

        if(state == State.Attack)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(monsterTrn.position, attackDist);
        }
    }
}
