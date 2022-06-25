using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour, EnemyInterface
{
    public enum State
    {
        IDLE,
        ATTACK,
        TRACE,
        DIE,
        PLAYERDIE,
    }

    public State state = State.IDLE;

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
    private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashhit = Animator.StringToHash("Hit");

    // Monster initial Life_Value
    private readonly int iniHP = 50;
    public int currHP;

    [Header("-------Effects-------")]
    public ParticleSystem die_effect = null;

    private void Awake()
    {
        // Set Monster HP
        currHP = iniHP;

        monsterTrn = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        targetTrn = GameObject.FindWithTag(ConstantManager.TAG_PLAYER).GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
    }

    private void OnEnable()
    {
        state = State.IDLE;
        currHP = iniHP;

        isDie = false;

        //GetComponent<CapsuleCollider>().enabled = true;
        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    private void Update()
    {
        //if (agent.remainingDistance >= 2f)
        //{
        //    Vector3 direction = agent.desiredVelocity;
        //    if (direction == null) return;

        //    Quaternion rotation = Quaternion.LookRotation(direction);
        //    monsterTrn.rotation = Quaternion.Slerp(monsterTrn.rotation, rotation, Time.deltaTime * 10f);
        //}
    }

    private IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);
            if (state == State.PLAYERDIE)
                yield break;

            if (state == State.DIE)
                yield break;

            float _dis = Vector3.Distance(monsterTrn.position, targetTrn.position);

            if (_dis <= attackDist)
                state = State.ATTACK;

            else if (_dis <= traceDist)
                state = State.TRACE;

            else
                state = State.IDLE;

        }
    }

    private IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;

                case State.TRACE:
                    agent.SetDestination(targetTrn.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;

                case State.ATTACK:
                    anim.SetBool(hashAttack, true);
                    break;


                case State.DIE:
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

                case State.PLAYERDIE:
                    StopAllCoroutines();

                    agent.isStopped = true;
                    anim.SetFloat(hashSpeed, Random.Range(0.5f, 1.3f));
                    anim.SetTrigger(hashPlayerDie);

                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDrawGizmos()
    {
        if (state == State.TRACE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(monsterTrn.position, traceDist);
        }

        if (state == State.ATTACK)
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
            state = State.DIE;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ConstantManager.TAG_BULLET))
        {

        }
    }
}
