using UnityEngine;

public class DragonImmortal : MonoBehaviour
{
    private SphereCollider sphereCollider;

    private void Start()
    {
        // Get the Sphere Collider component attached to the GameObject
        sphereCollider = GetComponent<SphereCollider>();

        // Call the ActivateColliderAfterDelay function after 0.75 seconds
        Invoke("ActivateColliderAfterDelay", 0.75f);
    }

    private void ActivateColliderAfterDelay()
    {
        // Find the child GameObject with the desired name
        GameObject immortalEffect = transform.Find("ImmortalVFX").gameObject;

        // Destroy the child GameObject
        if (immortalEffect != null)
        {
            Destroy(immortalEffect);
        }

        // Activate the collider
        sphereCollider.enabled = true;
    }
}