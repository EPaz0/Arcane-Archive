using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform fromPoint;
    public Transform playerRespawnPoint;
    public Vector3 playerDir;
    public Vector3 playerDirNorm;

    [SerializeField] LayerMask layerMask;
    bool rayHitPlayer;

    [SerializeField] GameObject[] waypoints;
    private int currentWaypoint;

    [SerializeField] int attackDistance;
    [SerializeField] AudioSource intenseAudio;

    public bool enemySeesPlayer;

    public float currentTime;
    public float teleportTime;

    public Image redVignette;
    public Color vignetteColor;
    public float vignetteSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //agent.destination = player.position;
        agent.destination = waypoints[currentWaypoint].transform.position;

        currentTime = teleportTime;

        vignetteColor = redVignette.color;
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

        playerDir = player.position - fromPoint.position;
        playerDirNorm = playerDir.normalized;

        if(enemySeesPlayer)
        {
            currentTime += Time.deltaTime;
        }

        else
        {
            currentTime = 0;
        }

        if(currentTime >= teleportTime)
        {
            TeleportPlayer();
            currentTime = 0;
        }

        vignetteColor.a = currentTime * vignetteSpeed;

        redVignette.color = vignetteColor;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(fromPoint.position, playerDirNorm, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(fromPoint.position, playerDirNorm * hit.distance, Color.yellow);
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.DrawRay(fromPoint.position, playerDirNorm * hit.distance, Color.red);
                Debug.Log("Did Hit");
                rayHitPlayer = true;
            }

            else
            {
                rayHitPlayer = false;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player in trigger");
            if (rayHitPlayer)
            {
                Debug.Log("EnemyChasing");

                enemySeesPlayer = true;

                agent.transform.LookAt(player.position);

                if (Vector3.Distance(transform.position, other.transform.position) <= attackDistance)
                {
                    agent.destination = transform.position;
                }
                else
                {
                    agent.destination = other.transform.position;
                }
            }
            else
            {
                enemySeesPlayer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            intenseAudio.volume = 1;
            //Invoke(nameof(TeleportPlayer), 3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            intenseAudio.volume = 0;
            //CancelInvoke(nameof(TeleportPlayer));
            enemySeesPlayer = false;
        }
    }

    public void TeleportPlayer()
    {
        Debug.Log("teleport");
        player.transform.position = playerRespawnPoint.position;
    }
}
