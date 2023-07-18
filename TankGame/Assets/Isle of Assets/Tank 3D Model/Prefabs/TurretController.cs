using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float turretRotateSpeed = 80f; // Speed of turret rotation

    private void Update()
    {
        // Rotate the turret based on mouse input
        RotateTurret();
    }

    private void RotateTurret()
    {
        // Get the mouse movement on the horizontal axis (left/right)
        float rotateX = Input.GetAxis("Mouse X");

        // Calculate the rotation amount based on mouse movement and rotation speed
        float rotationAmount = rotateX * turretRotateSpeed * Time.deltaTime;

        // Rotate the turret around the Y axis (up/down)
        transform.Rotate(0f, rotationAmount, 0f);
    }
}

