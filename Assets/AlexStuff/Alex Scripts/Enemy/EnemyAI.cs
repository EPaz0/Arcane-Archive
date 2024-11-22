using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    [SerializeField] GameObject[] waypoints;
    private int currentWaypoint;

    [SerializeField] int attackDistance;
    // Start is called before the first frame update
    void Start()
    {
        //agent.destination = player.position;
        agent.destination = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = player.position;

        if (Vector3.Distance(agent.destination, transform.position) <= 2)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            agent.destination = waypoints[currentWaypoint].transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            agent.transform.LookAt(player.position);

            if (Vector3.Distance(transform.position, other.transform.position) <= attackDistance)
            {
                agent.destination = transform.position;
                Debug.Log("attack");
            }
            else
            {
                agent.destination = other.transform.position;
            }

        }
    }
}
