using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayer : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform player;
    [SerializeField] private LayerMask groundLayer, playerLayer;
    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] private float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public GameObject projectile;

    //States
    [SerializeField] float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [SerializeField] private Animator moveAnimator;

    private void Awake()
    {
        player = GameObject.Find(Constants.PLAYER_OBJECT).transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        //Check for sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        if (!playerInSightRange)
        {
            GameController.isDetected = false;
            Patroling();
        }

        if (playerInSightRange)
        {
            GameController.isDetected = true;
            ChasePlayer();
        }
    }

    private void Patroling()
    {
        this.GetComponent<AudioSource>().enabled = false;
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            WalkingAnimation();
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer))
        {
            walkPointSet = true;
            WalkingAnimation();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.localPosition);
        this.GetComponent<AudioSource>().enabled = true;
        float distance = Vector3.Distance(player.position, gameObject.GetComponent<Transform>().position);
        if (distance < 1)
        {
            GameController.isCaught = true;
        }
    }

    void WalkingAnimation()
    {
        moveAnimator.SetFloat("MoveSpeed", 1);
    }

}
