using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    public GameObject liveID;

    public Image vidaEnemy;
    public float vidaMax;
    public float vidaActual;
    private bool dead = false;
    public GameObject enemyLiveID;

    public GameObject orbe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaAriz"))
        {
            vidaActual = vidaActual - 30f;
        }
        if (other.CompareTag("Patada"))
        {
            vidaActual = vidaActual - 5f;
        }
    }

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        transformPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.PATROL;
        InvokeRepeating("GeneratePatrolPosition", 0f, 5f);
        InvokeRepeating("Attack", 0f, 2f);
    }

    public void GeneratePatrolPosition()
    {
        destinationPoint = transform.position + (Vector3.right * Random.Range(-patrolArea.x, patrolArea.x)) + (Vector3.forward * Random.Range(-patrolArea.y, patrolArea.y));
    }

    public void Attack()
    {
        if (Vector3.Distance(transform.position, transformPlayer.position) < 3 && liveID.activeInHierarchy == true)
        {
            enemyAnimator.SetTrigger("Attack");
        }
        if (liveID.activeInHierarchy == false)
        {
            currentState = EnemyState.PATROL;
        }
    }

    void Update()
    {
        vidaEnemy.fillAmount = vidaActual / vidaMax;
        if (door.activeInHierarchy == false && liveID.activeInHierarchy == true)
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

        //Contador vida y morir
        if (vidaActual <= 0f && dead == false)
        {
            orbe.SetActive(true);
            enemyAnimator.SetTrigger("Dead");//Falta animación muerte
            Debug.Log("Se murio este perro");
            enemyLiveID.SetActive(false);
            dead = true;
        }

    }
}

public enum EnemyState
{
    PATROL,
    CHASE
}
