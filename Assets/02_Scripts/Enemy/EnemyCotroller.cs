using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum State
{
    IDLE,
    TRACE,
    ATTACK,
    DIE,
}

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyCotroller : MonoBehaviour, EnemyInterface
{
    [SerializeField] private State state = State.IDLE;

    private NavMeshAgent agent = null;
    private Animator anim = null;


    public Transform targetTrn = null;

    public float traceDist = 40f;
    public float attackDist = 4f;
    private bool isDie = false;


    // Get HashTable Values
    private readonly int hashTrace = Animator.StringToHash("isTrace");
    private readonly int hashAttack = Animator.StringToHash("isAttack");
    private readonly int hashDie = Animator.StringToHash("Die");
    private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");
    private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashhit = Animator.StringToHash("Hit");

    private WaitForSeconds wait_enemy = new WaitForSeconds(0.3f);

    private readonly int iniHP = 50;
    public int currHP;
    [Header("-------Effects-------")]
    public ParticleSystem die_effect = null;

    private void Start()
    {
        currHP = iniHP;

        agent = GetComponent<NavMeshAgent>();
        targetTrn = GameObject.FindGameObjectWithTag(ConstantManager.TAG_PLAYER).GetComponent<Transform>();
        anim = GetComponent<Animator>();

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    private void Update()
    {
        LookEnemyPlayer();
    }

    private void LookEnemyPlayer()
    {
        //if (agent.remainingDistance >= 2f)
        //{
        var direction = agent.desiredVelocity;
        //    if (direction == null) return;

        //    var rotation = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
        //}

        var rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }

    private IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return wait_enemy;
            if (state == State.DIE) yield break;

            var _dis = Vector3.Distance(transform.position, targetTrn.position);

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
                    //StartCoroutine(Throw());

                    //anim.SetBool(hashTrace, true);
                    //anim.SetBool(hashAttack, false);
                    break;


                case State.ATTACK:
                    anim.SetBool(hashAttack, true);
                    break;
            }
            yield return wait_enemy;
        }
    }


    private void OnDrawGizmos()
    {
        if (state == State.TRACE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, traceDist);
        }

        if (state == State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDist);
        }
    }

    public void Damage(int _damage)
    {
        currHP -= 10;
        GameManager.Instance.itemCnt++;

        if (GameManager.Instance.itemCnt % 3 == 0)
        {

        }

        if (currHP <= 0)
        {
            die_effect.gameObject.SetActive(true);

            Invoke(nameof(PlayerDie), 0.3f);
        }
    }

    private void PlayerDie()
    {
        Destroy(gameObject);
    }

    private IEnumerator Throw()
    {
        while (true)
        {

            yield return null;
        }
    }
}
