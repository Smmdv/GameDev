using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;  // Reference to the enemy prefab

    public float minSpawnInterval = 2f;  // Minimum time interval between enemy spawns
    public float maxSpawnInterval = 5f;  // Maximum time interval between enemy spawns
    public float speedIncreaseInterval = 60f; // Interval for increasing enemy speed
    public float initialSpeed = 5f; // Initial speed of the enemy

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
        StartCoroutine(IncreaseSpeed());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Instantiate a new enemy at the spawner's position and rotation
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

            // Get the ConstantMovement component from the spawned enemy
            ConstantMovement movement = enemy.GetComponent<ConstantMovement>();

            // Set the initial speed of the enemy based on the current speed increase
            movement.speed = initialSpeed + (Time.time / speedIncreaseInterval);

            // Set the base speed of the enemy to the initial speed
            movement.baseSpeed = movement.speed;

            // Generate a random spawn interval between the specified min and max values
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            yield return new WaitForSeconds(randomInterval);
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            // Wait for the specified speed increase interval
            yield return new WaitForSeconds(speedIncreaseInterval);

            // Find all the enemies in the scene with the ConstantMovement component
            ConstantMovement[] enemies = FindObjectsOfType<ConstantMovement>();

            // Increase the speed of each enemy
            foreach (ConstantMovement enemy in enemies)
            {
                if (enemy.speed > enemy.baseSpeed)
                {
                    enemy.baseSpeed = enemy.speed; // Set the base speed to the current speed
                }

                enemy.speed += 1f; // Increase the speed by 1 (you can adjust the value as desired)
            }
        }
    }
}
