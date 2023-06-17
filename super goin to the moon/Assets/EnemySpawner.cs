using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    public float spawnInterval = 2f;  // Time interval between enemy spawns

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

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
