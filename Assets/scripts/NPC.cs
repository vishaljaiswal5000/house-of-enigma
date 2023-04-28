using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private Transform player;
    [SerializeField] private LayerMask playerLayer;

    //Patroling
    public Vector3 walkPoint;

    [SerializeField] float sightRange;
    public bool playerInSightRange;

    float sightRange1;

    // Start is called before the first frame update
    void Start()
    {
        walkPoint = this.transform.position;
        player = GameObject.Find(Constants.PLAYER_OBJECT).transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        sightRange1 = sightRange;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        if (!playerInSightRange)
        {
            //GameController.isDetected = false;
            Patroling();
        }

        if (playerInSightRange)
        {
            GameController.isDetected = true;
            sightRange = 15f;
            ChasePlayer();
        }

        float distance = Vector3.Distance(player.position, gameObject.GetComponent<Transform>().position);
        if (distance <= 1)
        {
            GameController.isCaught = true;
        }

    }

    private void ChasePlayer()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(player.transform.position, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            //transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
            animator.SetBool("IsWalk", true);
            agent.SetDestination(player.transform.position);
            this.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            Patroling();
        }
    }

    private void Patroling()
    {
        this.GetComponent<AudioSource>().enabled = false;
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(walkPoint, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            if (Vector3.Distance(agent.transform.position, walkPoint) < 0.15f)
            {
                animator.SetBool("IsWalk", false);
                sightRange = sightRange1;
            }
            else
            {
                agent.SetDestination(walkPoint);
                //transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
                animator.SetBool("IsWalk", true);
            }
        }
        else
        {
            //walkPoint = transform.position;
            agent.SetDestination(transform.position);
            animator.SetBool("IsWalk", false);
        }
    }
}
