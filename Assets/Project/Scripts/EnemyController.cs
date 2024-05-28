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
    private float vidaMax = 200f;
    private float vidaActual = 200f;
    private float danGolpe = 30f;
    private float danPatada = 5f;
    private bool dead = false;
    private bool deadID = false;
    public GameObject enemyLiveID;
    public GameObject Ariz;

    public GameObject orbe;
    public GameObject arma;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaAriz") && vidaActual > 70)
        {
            enemyAnimator.SetTrigger("Pain1");
            vidaActual = vidaActual - danGolpe;
            Ariz.gameObject.SendMessage("PainGuardianSFX");
        }
        if (other.CompareTag("Patada") && vidaActual > 70)
        {
            enemyAnimator.SetTrigger("Pain2");
            vidaActual = vidaActual - danPatada;
            Ariz.gameObject.SendMessage("PainGuardianSFX");
        }
        if (other.CompareTag("ArmaAriz") && vidaActual <= 70)
        {
            vidaActual = vidaActual - danGolpe;
            Ariz.gameObject.SendMessage("PainGuardianSFX");
        }
        if (other.CompareTag("Patada") && vidaActual <= 70)
        {
            vidaActual = vidaActual - danPatada;
            Ariz.gameObject.SendMessage("PainGuardianSFX");
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
        if (Vector3.Distance(transform.position, transformPlayer.position) < 3 && liveID.activeInHierarchy == true && dead == false)
        {
            enemyAnimator.SetTrigger("Attack");
            Ariz.gameObject.SendMessage("AttackGuardianSFX");
        }
        if (liveID.activeInHierarchy == false && dead == false)
        {
            currentState = EnemyState.PATROL;
        }
    }

    void Update()
    {
        if (dead == false)
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
                enemyAnimator.SetFloat("Speed", 0f);
                enemyAnimator.SetTrigger("Dead");
                enemyLiveID.SetActive(false);//Tal vez no se necesite
                dead = true;
                deadID = true;
                arma.SetActive(false);
                Ariz.gameObject.SendMessage("DeadGuardianSFX");
            }
        }
        else if (dead == true && deadID == true)
        {
            deadID = false;
        }
    }
}

public enum EnemyState
{
    PATROL,
    CHASE
}
