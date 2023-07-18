using UnityEngine;

public class EnemySphereAI : MonoBehaviour
{
    public Transform playerTank;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float turretRotateSpeed = 5f; // Add this variable
    public float fireRate = 2f;
    public float fireRange = 20f;
public GameObject turret;


    public Transform muzzlePoint; // Assigned in the Inspector

    private Transform turretTransform;
    private float fireCooldown = 0f;

    private void Awake()
    {
        turretTransform = transform.Find("Turret");
    }

    private void Update()
    {
        if (playerTank == null || muzzlePoint == null)
        {
            Debug.LogError("Player tank or muzzle point is not assigned in EnemySphereAI.");
            return;
        }

        // Check if the player tank is in the firing range
        float distanceToPlayer = Vector3.Distance(transform.position, playerTank.position);
        if (distanceToPlayer <= fireRange)
        {
        
            // Rotate the turret towards the player tank
            Vector3 targetDirection = playerTank.position - turretTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, targetRotation, turretRotateSpeed * Time.deltaTime);

            // Fire bullets when the cooldown allows
            FireBullet();
        }
        else
        {
            // Move towards the player tank
            Vector3 moveDirection = (playerTank.position - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    private void FireBullet()
    {
        // Check the fire cooldown to limit the rate of fire
        if (fireCooldown <= 0f)
        {
            // Instantiate the bullet prefab at the muzzle point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);

            // Adjust bullet speed if needed
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10f;

            // Reset the fire cooldown
            fireCooldown = 1f / fireRate;
        }

        // Reduce the fire cooldown
        fireCooldown -= Time.deltaTime;
    }
}

