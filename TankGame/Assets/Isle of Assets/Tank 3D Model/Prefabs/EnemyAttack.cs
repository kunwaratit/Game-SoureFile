using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject targetTank; // Reference to the player-controlled tank
    public GameObject projectilePrefab; // Prefab of the projectile to be thrown
    public Transform throwPoint; // The point from where the projectile is thrown
    public Transform turret; // The turret of the tank that needs to rotate horizontally
    public Transform muzzle; // The muzzle of the tank that needs to rotate
    public float throwForce = 10f; // The force with which the projectile is thrown
    public float rotationSpeed = 20f; // The speed at which the turret rotates towards the target tank
    public float throwInterval = 3f; // Time between each throw
    public float detectionRange = 20f; // The range at which the enemy tank detects the main tank

    private float nextThrowTime;

    private void Start()
    {
        nextThrowTime = Time.time + throwInterval;
    }

    private void Update()
    {
        if (targetTank == null)
        {
            // If the player-controlled tank is destroyed or not set, stop attacking
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, targetTank.transform.position);
        if (distanceToTarget <= detectionRange)
        {
            RotateTurretTowardsTarget();

            if (Time.time >= nextThrowTime)
            {
                ThrowProjectile();
                nextThrowTime = Time.time + throwInterval;
            }
        }
    }

    private void RotateTurretTowardsTarget()
    {
        // Calculate the direction towards the player tank
        Vector3 directionToPlayerTank = (targetTank.transform.position - turret.position).normalized;

        // Calculate the rotation to look at the player tank, but only rotate on the y-axis (yaw)
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToPlayerTank.x, 0f, directionToPlayerTank.z));

        // Smoothly rotate the turret horizontally towards the player tank
        turret.rotation = Quaternion.Slerp(turret.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void ThrowProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        if (projectileRigidbody != null)
        {
            // Calculate the direction towards the player tank
            Vector3 directionToPlayerTank = (targetTank.transform.position - throwPoint.position).normalized;

            // Apply the throw force in the direction towards the player tank
            projectileRigidbody.velocity = directionToPlayerTank * throwForce;
        }
    }
}

