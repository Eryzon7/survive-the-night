using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // assign your enemy prefab in the inspector
    public Transform[] spawnPoints; // optional: assign spawn points in the inspector
    public float spawnInterval = 10f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Random offset around the spawn point
        Vector3 randomOffset = new Vector3(
            Random.Range(-5f, 5f),      // X offset
            Random.Range(-5f, 5f),      // Y offset (0 if you're spawning on a flat surface)
            0f                          // Z offset
               
        );

        Vector3 spawnPosition = spawnPoint.position + randomOffset;

        Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);
    }
}

