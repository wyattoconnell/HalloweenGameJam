using System.Collections;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public Transform[] spawnPoints;
    public float spawnDelay;

    private int currentSpawnIndex = 0; 

    void Start()
    {
        StartCoroutine(SpawnGhostsIndefinitely());
    }

    IEnumerator SpawnGhostsIndefinitely()
    {
        while (true)
        {
            Transform spawnPoint = spawnPoints[currentSpawnIndex];

            Instantiate(ghostPrefab, spawnPoint.position, spawnPoint.rotation);
            currentSpawnIndex++;

            if (currentSpawnIndex >= spawnPoints.Length)
            {
                currentSpawnIndex = 0;
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
