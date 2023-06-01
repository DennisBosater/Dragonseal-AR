using UnityEngine;

public class ObeliskEffect : MonoBehaviour
{
    public float slowdownFactor = 0.75f; // The factor by which to slow down the speed (25% slowdown = 0.75)

    private void Update()
    {
        GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");

        foreach (GameObject dragon in dragons)
        {
            Rigidbody dragonRigidbody = dragon.GetComponent<Rigidbody>();

            if (dragonRigidbody != null)
            {
                // Slow down the velocity of the dragon
                dragonRigidbody.velocity *= slowdownFactor;
            }
        }
    }
}
