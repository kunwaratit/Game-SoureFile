using UnityEngine;

public class EnemySphereSpawner : MonoBehaviour
{
    public GameObject enemySpherePrefab;
    public Transform playerTank;
    public int numberOfEnemies = 2;
    public float spawnRadius = 10f;

    private void Start()
    {
        SpawnEnemySpheres();
    }
    private void SpawnEnemySpheres()
{
    for (int i = 0; i < numberOfEnemies; i++)
    {
        // Calculate a random position around the player tank within the spawnRadius
        Vector3 spawnPosition = playerTank.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f; // Set the Y position to zero to ensure enemies are on the same plane

        // Instantiate the enemy sphere at the calculated position
        GameObject enemySphere = Instantiate(enemySpherePrefab, spawnPosition, Quaternion.identity);

        // Get the EnemySphereAI component of the instantiated enemy sphere
        EnemySphereAI enemySphereAI = enemySphere.GetComponent<EnemySphereAI>();

        // Assign the player tank transform reference to the playerTank variable in the EnemySphereAI script
        if (enemySphereAI != null)
        {
            enemySphereAI.playerTank = playerTank;
        }
        else
        {
            Debug.LogError("EnemySphereAI script not found on the enemy sphere prefab.");
        }
    }
}

}

