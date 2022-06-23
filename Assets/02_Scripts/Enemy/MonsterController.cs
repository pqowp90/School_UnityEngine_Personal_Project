using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour, EnemyInterface
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
    private Animator anim = null;
    private NavMeshAgent agent = null;

    // Get HashTable Values
    private readonly int hashTrace = Animator.StringToHash("isTrace");
    private readonly int hashAttack = Animator.StringToHash("isAttack");
    private readonly int hashDie = Animator.StringToHash("Die");
    private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");

    // Monster initial Life_Value
    private readonly int iniHP = 50;
    public int currHP;

    [Header("-------Effects-------")]
    public ParticleSystem die_effect = null;

    private void Start()
    {
        // Set Monster HP
        currHP = iniHP;

        monsterTrn = GetComponent<Transform>();
        targetTrn = GameObject.FindWithTag(ConstantManager.TAG_PLAYER).GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
    }

    private void OnEnable()
    {
        state = State.Idle;
        currHP = iniHP;

        isDie = false;

        GetComponent<CapsuleCollider>().enabled = true;
        StartCoroutine(CheckMonsterState());

    }

    private IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);
            if (state == State.PlayerDie)
                yield break;

            if (state == State.Die)
                yield break;

            float _dis = Vector3.Distance(monsterTrn.position, targetTrn.position);

            if (_dis <= attackDist)
                state = State.Attack;

            else if (_dis <= traceDist)
                state = State.Trace;

            else
                state = State.Idle;

        }
    }

    private IEnumerator MonsterAction()
    {
        while (!isDie)
        {


            switch (state)
            {
                case State.Idle:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;

                case State.Trace:
                    agent.SetDestination(targetTrn.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;

                case State.Attack:
                    anim.SetBool(hashAttack, true);
                    break;


                case State.Die:
                    isDie = true;
                    agent.isStopped = true;
                    anim.SetTrigger(hashDie);

                    GetComponent<CapsuleCollider>().enabled = false;

                    //SphereCollider[] spheres = GetComponentsInChildren<SphereCollider>();
                    //foreach (SphereCollider sphere in spheres)
                    //{
                    //    sphere.enabled = false;
                    //}

                    yield return new WaitForSeconds(3f);

                    gameObject.SetActive(false);
                    break;

                case State.PlayerDie:
                    StopAllCoroutines();

                    agent.isStopped = true;
                    //anim.SetFloat(hashSpeed, Random.Range(0.5f, 1.3f));
                    anim.SetTrigger(hashPlayerDie);

                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDrawGizmos()
    {
        if (state == State.Trace)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(monsterTrn.position, traceDist);
        }

        if (state == State.Attack)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(monsterTrn.position, attackDist);
        }
    }

    public void Damage(int _damage)
    {
        currHP -= 10;

        if (currHP <= 0)
        {
            die_effect.Play();
            state = State.Die;
        }
    }
}
