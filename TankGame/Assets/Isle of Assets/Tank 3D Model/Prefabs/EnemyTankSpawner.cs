using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{
    public GameObject enemyTankPrefab;
    public int numberOfEnemies = 5;

    public GameObject playerTank;

    private bool hasSpawned = false; // Add this line

    private void Start()
    {
        SpawnEnemyTanks();
    }

    private void SpawnEnemyTanks()
    {
        if (hasSpawned) return; // Add this line

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Calculate random position around the player tank
            Vector3 randomOffset = Random.insideUnitSphere * 10f;
            Vector3 spawnPosition = playerTank.transform.position + randomOffset;

            // Instantiate the enemy tank at the calculated position
            GameObject enemyTank = Instantiate(enemyTankPrefab, spawnPosition, Quaternion.identity);

            // Attach the player tank's transform reference to the EnemyTankAI script of the enemy tank
            EnemyTankAI enemyAI = enemyTank.GetComponent<EnemyTankAI>();
            enemyAI.playerTank = playerTank.transform;
        }

        hasSpawned = true; // Add this line
    }
}

