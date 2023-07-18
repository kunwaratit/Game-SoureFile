using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the bullet deals

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collides with an enemy tank
        EnemyTankAI enemyTank = collision.gameObject.GetComponent<EnemyTankAI>();
        if (enemyTank != null)
        {
            enemyTank.TakeDamage(damageAmount); // Call the TakeDamage method of the enemy tank
            Destroy(gameObject); // Destroy the bullet when it hits an enemy tank
        }
    }
}

