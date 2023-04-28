using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        Debug.Log("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(Player.transform.position, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                agent.SetDestination(Player.transform.position);
            }
            else
            {
                Debug.Log("²»¿É´ï");
            }
        }
    }
}
