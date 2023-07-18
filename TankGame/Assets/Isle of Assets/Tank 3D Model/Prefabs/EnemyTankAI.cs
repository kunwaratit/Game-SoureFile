using UnityEngine;

public class EnemyTankAI : MonoBehaviour
{
    public Transform playerTank;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float turretRotateSpeed = 5f;
    public float fireRate = 2f;
    public float fireRange = 20f;
    public int maxHealth = 100; // Maximum health of the enemy tank

    public int currentHealth; // Current health of the enemy tank
    public Transform turretTransform;
    public float fireCooldown = 0f;

    private void Awake()
    {
        turretTransform = transform.Find("Turret");
        currentHealth = maxHealth; // Set the current health to the maximum health when the tank is spawned
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTank.position);

        // Check if the player tank is in the firing range
        if (distanceToPlayer <= fireRange)
        {
            FireBullet();
        }

        // Move towards the player tank
        Vector3 moveDirection = (playerTank.position - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Rotate the turret towards the player tank
        Vector3 targetDirection = playerTank.position - turretTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, targetRotation, turretRotateSpeed * Time.deltaTime);
    }

    private void FireBullet()
    {
        // Check the fire cooldown to limit the rate of fire
        if (fireCooldown <= 0f)
        {
            // Instantiate the bullet prefab at the muzzle point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, turretTransform.position, turretTransform.rotation);

            // Adjust bullet speed if needed
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10f;

            // Reset the fire cooldown
            fireCooldown = 1f / fireRate;
        }

        // Reduce the fire cooldown
        fireCooldown -= Time.deltaTime;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Remove the enemy tank from the scene when its health reaches zero
        }
    }
}

