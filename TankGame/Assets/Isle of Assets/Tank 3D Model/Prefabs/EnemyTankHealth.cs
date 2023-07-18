using UnityEngine;

public class EnemyTankHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Tank destroyed, handle any destruction logic here (e.g., play explosion effect, award points, etc.)
            Destroy(gameObject);
        }
    }
}

