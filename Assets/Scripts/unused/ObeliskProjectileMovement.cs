using UnityEngine;

public class ObeliskProjectileMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    private float timer;

    private void Start()
    {
        // Set the timer to track the projectile's lifetime
        timer = 0f;
    }

    private void Update()
    {
        // Move the projectile forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Increment the timer
        timer += Time.deltaTime;

        // Destroy the projectile after its lifetime has elapsed
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the projectile if it collides with anything
        //Destroy(gameObject);
    }
}
