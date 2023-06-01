using UnityEngine;

public class ObeliskAOE : MonoBehaviour
{
    public float slowFactor = 0.5f; // The factor by which the speed is reduced

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a Rigidbody component
        Rigidbody otherRb = collision.collider.GetComponent<Rigidbody>();
        if (otherRb != null)
        {
            // Reduce the velocity of the colliding object
            otherRb.velocity *= slowFactor;
        }
    }
}
