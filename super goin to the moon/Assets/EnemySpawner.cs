using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    public float minSpawnInterval = 2f;  // Minimum time interval between enemy spawns
    public float maxSpawnInterval = 5f;  // Maximum time interval between enemy spawns

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Instantiate a new enemy at the spawner's position and rotation
            Instantiate(enemyPrefab, transform.position, transform.rotation);

            // Generate a random spawn interval between the specified min and max values
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(randomInterval);
        }
    }
}
