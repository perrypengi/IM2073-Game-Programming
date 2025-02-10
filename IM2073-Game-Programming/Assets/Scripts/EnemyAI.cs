using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 5f;
    public float speed = 2f;
    private Vector3 startPosition;
    public Transform[] patrolPoints;
    private int currentPatrolIndex;

    void Start()
    {
        startPosition = transform.position;
        currentPatrolIndex = 0;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < chaseDistance)
        {
            transform.LookAt(player);
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        Transform targetPatrolPoint = patrolPoints[currentPatrolIndex];
        transform.LookAt(targetPatrolPoint);
        transform.position = Vector3.MoveTowards(transform.position, targetPatrolPoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPatrolPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if ((player.transform.position - transform.position).magnitude < 2.0f)
        {
            SceneManager.LoadScene("LoseEnding"); // load (lose)ending scene when caught by ghosts
        }
    }
}
