using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform player; 
    public float maxRiseHeight = 0.5f; 
    public float minRiseHeight = 0f; 
    public float minRiseSpeed = 1f; 
    public float maxRiseSpeed = 3f; 
    public float minMoveSpeed = 3f; 
    public float maxMoveSpeed = 100f; 
    public float detectionRange = 10f; 
    public float undergroundOffset = 5f; 

    private bool isRising = false; 
    private bool isChasing = false; 

    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    private float riseSpeed; 
    private float moveSpeed; 

    void Start()
    {
        float randomHeight = Random.Range(minRiseHeight, maxRiseHeight); 
        riseSpeed = Random.Range(minRiseSpeed, maxRiseSpeed);
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        startPosition = transform.position;
        targetPosition = new Vector3(startPosition.x, startPosition.y + randomHeight, startPosition.z);
        transform.position = new Vector3(startPosition.x, startPosition.y - undergroundOffset, startPosition.z); 
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
