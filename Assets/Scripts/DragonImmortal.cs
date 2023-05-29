using UnityEngine;

public class DragonImmortal : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private GameObject immortalEffect;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        immortalEffect = transform.Find("ImmortalVFX").gameObject;

        Invoke("NoLongerImmortal", 1.25f);
    }

    private void NoLongerImmortal()
    {
        sphereCollider.enabled = true;

        // Sphere Collider settings
        sphereCollider.radius = 3.5f;
        sphereCollider.center = new Vector3(0.0f, 5.0f, 0.0f);

        if (immortalEffect != null)
        {
            Destroy(immortalEffect.gameObject);
        }
    }
}