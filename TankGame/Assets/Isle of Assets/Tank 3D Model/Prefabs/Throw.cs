using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject spherePrefab; // Prefab of the sphere to be thrown
    public Transform throwPoint; // The point from where the sphere is thrown
    public float throwForce = 10f; // The force with which the sphere is thrown
    public float throwInterval = 2f; // Time between each throw

    private float nextThrowTime;

    private void Start()
    {
        nextThrowTime = Time.time + throwInterval;
    }

    private void Update()
    {
        if (Time.time >= nextThrowTime)
        {
            ThrowSphere();
            nextThrowTime = Time.time + throwInterval;
        }
    }

    private void ThrowSphere()
    {
        GameObject sphere = Instantiate(spherePrefab, throwPoint.position, Quaternion.identity);
        Rigidbody sphereRigidbody = sphere.GetComponent<Rigidbody>();
        if (sphereRigidbody != null)
        {
            // Apply the throw force in the forward direction of the cylinder
            sphereRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}

