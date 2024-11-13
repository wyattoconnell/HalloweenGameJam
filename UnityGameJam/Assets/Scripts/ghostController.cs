using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform player; 
    public float riseSpeed = 2f; 
    public float moveSpeed = 5f; 
    public float detectionRange = 10f; 
    public float maxRiseHeight = 1f; 

    private bool isRising = false; 
    private bool isChasing = false; 

    private Vector3 startPosition; 
    private Vector3 targetPosition; 

    void Start()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(startPosition.x, startPosition.y + maxRiseHeight, startPosition.z); 
        transform.position = new Vector3(startPosition.x, startPosition.y - 2f, startPosition.z); 
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (!isRising)
        {
            isRising = true;
        }

        if (isRising && !isChasing)
        {
            RiseOutOfGround();
        }

        if (isChasing)
        {
            ChasePlayer();
        }
    }

    void RiseOutOfGround()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, riseSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isRising = false;
            isChasing = true;
        }
    }

    void ChasePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0f, directionToPlayer.z)); 
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); 
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
