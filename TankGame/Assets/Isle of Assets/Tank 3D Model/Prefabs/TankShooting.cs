using UnityEngine;
using System.Collections; // Add this using directive for IEnumerator

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float shootForce = 10f;
    public AudioClip firingSound;

    public AudioSource firingAudioSource;
    
    public float fireDelay = 2f;
    private bool canFire = true;

    private void Start()
    {
        StartCoroutine(ResetFireDelay());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            FireBullet();

            firingAudioSource.Play();
            StartCoroutine(ResetFireDelay());
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(muzzlePoint.forward * shootForce, ForceMode.Impulse);
    }

    private IEnumerator ResetFireDelay()
    {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }
}

