using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float decisionDelay = 1f;
    [SerializeField] Transform objectToChase;
    [SerializeField] Transform[] waypoints;
    int currentWaypoint = 0;
    public float speed;
    public AudioSource audioSource;
    public AudioClip notice;

    enum EnemyStates
    {
        Patrolling,
        Chasing
    }

    [SerializeField] EnemyStates currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetDestination", 0.5f, decisionDelay);
        if (currentState == EnemyStates.Patrolling)
            agent.SetDestination(waypoints[currentWaypoint].position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, objectToChase.position) > 10f)
        {
            currentState = EnemyStates.Patrolling;
        }
        else
        {
            currentState = EnemyStates.Chasing;
        }
        if (currentState == EnemyStates.Patrolling)
        {
            speed = 10;
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) <= 0.6f)
            {
                currentWaypoint++;
                if (currentWaypoint == waypoints.Length)
                {
                    currentWaypoint = 0;
                }
            }
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    void SetDestination()
    {
        if (currentState == EnemyStates.Chasing)
            agent.SetDestination(objectToChase.position);
        speed = 20;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Player")
        {

            SceneManager.LoadScene("Loss");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}