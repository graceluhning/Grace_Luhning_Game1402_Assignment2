using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float giveUpDistance;
    [SerializeField] private float chaseCheckAngle;
    [SerializeField] private Animator EnemyAnimator;
    private EnemyState _currentState;
    private Transform _currentTarget;
    private bool _isWaiting = false;

    [SerializeField] private Collider headCollider;
    
    void Awake()
    {
        
        if (headCollider == null)
            headCollider = GetComponent<Collider>();
        
        headCollider.enabled = false;
        
        if (EnemyAnimator == null)
            EnemyAnimator = GetComponent<Animator>();
        
        if(agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            
            if (player != null)
                playerTransform = player.transform;
            else
                Debug.LogError("Player NOT FOUND!");
        }
        
        _currentState = EnemyState.IDLE;
    }

    void FixedUpdate()
    {
        if(_currentState == EnemyState.IDLE)
        {
            EnemyAnimator.SetBool("Idle", true);
            EnemyAnimator.SetBool("Walk", false);
            EnemyAnimator.SetBool("Chase", false);
            headCollider.enabled = false;
            
            if(!_isWaiting)
                StartCoroutine(WaitAndChooseARandomPointAndMove(3));
            
            if(IsPlayerInRange() && IsInFOV())
            {
                _currentState = EnemyState.CHASE;
            }
        }
        else if(_currentState == EnemyState.PATROL)
        {
            if(agent.remainingDistance <= .2f)
            {
                _currentState = EnemyState.IDLE;
                EnemyAnimator.SetBool("Attack", false);
                EnemyAnimator.SetBool("Idle", false);
                EnemyAnimator.SetBool("Walk", true);
                EnemyAnimator.SetBool("Chase", false);
                headCollider.enabled = false;
            }

            
            if(IsPlayerInRange() && IsInFOV())
            {
                _currentState = EnemyState.CHASE;
            }

        }
        else if(_currentState == EnemyState.CHASE)
        {
            agent.SetDestination(playerTransform.position);
            EnemyAnimator.SetBool("Attack", false);
            EnemyAnimator.SetBool("Chase", true);
            EnemyAnimator.SetBool("Idle", false);
            EnemyAnimator.SetBool("Walk", false);
            headCollider.enabled = false;
            
            if(HasPlayerGoneAwayFromMeTooSAD())
            {
                _currentState = EnemyState.IDLE;
            }
            
            if (agent.remainingDistance <= 2f)
            {
                _currentState = EnemyState.ATTACK;
            }
        }
        else if (_currentState == EnemyState.ATTACK)
        {
            EnemyAnimator.SetBool("Attack", true);
            EnemyAnimator.SetBool("Chase", false);
            EnemyAnimator.SetBool("Idle", false);
            EnemyAnimator.SetBool("Walk", false);
            headCollider.enabled = true;

            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance > 5f)
            {
                EnemyAnimator.SetBool("Attack", false);
                _currentState = EnemyState.CHASE;
                headCollider.enabled = false;
            }
        }

        else if (_currentState == EnemyState.DIE)
        {
            EnemyAnimator.SetBool("Die", true);
        }
    }

    private IEnumerator WaitAndChooseARandomPointAndMove(float timeToWait)
    {
        _isWaiting = true;
        Debug.Log("Waiting to choose a random point");
        yield return new WaitForSeconds(timeToWait);
        _currentState = EnemyState.PATROL;
        EnemyAnimator.SetBool("Attack", false);
        EnemyAnimator.SetBool("Idle", true);
        EnemyAnimator.SetBool("Walk", false);
        EnemyAnimator.SetBool("Chase", false);
        ChooseARandomPointAndMove();
        _isWaiting = false;
    }


    private void ChooseARandomPointAndMove()
    {
        if(patrolPoints.Length <=0) return;
        _currentTarget = patrolPoints[Random.Range(0, patrolPoints.Length)];

        agent.SetDestination(_currentTarget.position);

    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, playerTransform.position) <= chaseDistance;
    }

    private bool HasPlayerGoneAwayFromMeTooSAD()
    {
        return Vector3.Distance(transform.position, playerTransform.position) >= giveUpDistance;
    }

    Vector3 _directionToPlayer;
    private bool IsInFOV()
    {
        _directionToPlayer = (playerTransform.position - transform.position).normalized;
        return Vector3.Angle(transform.forward, _directionToPlayer) <= chaseCheckAngle;
    }
}
