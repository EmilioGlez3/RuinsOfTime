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

    //Cosecha
    public GameObject door;


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
        destinationPoint = transform.position + (Vector3.right * Random.Range(-patrolArea.x, patrolArea.x)) + (Vector3.forward * Random.Range(-patrolArea.y, patrolArea.y));
    }

    void Update()
    {
        if (door.activeInHierarchy == false)
        {
            if (currentState != EnemyState.CHASE)
            {
                currentState = EnemyState.CHASE; ;
            }
        }

        if (currentState == EnemyState.PATROL)
        {
            agent.SetDestination(destinationPoint);
        }
        else if (currentState == EnemyState.CHASE)
        {
            agent.SetDestination(transformPlayer.position);
        }
        enemyAnimator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}
