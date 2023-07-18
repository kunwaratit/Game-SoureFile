using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of tank movement
    public float rotateSpeed = 80f; // Speed of tank rotation
 
  public AudioSource movementSound; // Assigned in the Inspector, stores reference to the AudioSource

    public int maxHealth = 100;
public int currentHealth;

  
  public Transform[] tracks;
  private void Start()
{
  currentHealth = maxHealth;
}
 public void DestroyTank()
    {
        // Add any custom logic here if needed, such as triggering a particle effect or sound
        Destroy(gameObject); // Destroy the tank GameObject
    }
    private void Update()
    {
        // Handle tank movement
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // Move the tank forward/backward based on the input
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed;
        transform.Translate(moveDirection * Time.deltaTime, Space.World);

        // Rotate the tank left/right based on the input
        float rotationAmount = rotateInput * rotateSpeed * Time.deltaTime;
        transform.Rotate(0f, rotationAmount, 0f);
        
        // Move the tracks with the tank
    
   if (Mathf.Abs(moveInput) > 0f)
        {
            if (!movementSound.isPlaying)
            {
                movementSound.Play();
            }
        }
        else
        {
            movementSound.Stop();
        }
}
public void TakeDamage(int damageAmount)
{
    currentHealth -= damageAmount;

    // Check if the tank is destroyed (health reaches zero or below)
    if (currentHealth <= 0)
    {
        DestroyTank(); // You can implement this method to handle tank destruction
    }
}



}

