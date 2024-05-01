using UnityEngine;
using UnityEngine.AI;

public class CatAI : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float wanderRadius = 20f;
    public float wanderTimer = 5f;
    public float closeDistance = 2f;

    private Transform player;
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (player != null && agent.enabled && agent.isOnNavMesh)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            // Check if the cat is very close to the player
            if (distance < closeDistance)
            {
                // Stop the cat
                agent.isStopped = true;
            }
            else
            {
                // Ensure the agent is moving
                agent.isStopped = false;

                if (distance < detectionRadius)
                {
                    // Chase the player
                    agent.SetDestination(player.position);
                }
                else if (timer >= wanderTimer)
                {
                    // Random wandering
                    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    timer = 0;
                }
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}