using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private NavMeshAgent agent;
    private Transform transformPlayer;

    public EnemyState currentState;
    public Vector2 patrolArea;
    private Vector3 destinationPoint;
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.PATROL;
        InvokeRepeating("GeneratePatrolPosition", 0f, 5f);//Se debe de quitar para los demas estados
    }

    public void GeneratePatrolPosition()
    {
        if(currentState != EnemyState.PATROL)
        {
            return;
        }

        destinationPoint = transform.position + (Vector3.right * Random.Range(-patrolArea.x, patrolArea.x)) + (Vector3.forward * Random.Range(-patrolArea.y, patrolArea.y));
    }

    void Update()
    {
        agent.SetDestination(destinationPoint);
        enemyAnimator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}
