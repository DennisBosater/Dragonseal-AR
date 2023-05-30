using UnityEngine;

public class ObeliskFunction : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    private InteractionManager interactionManager;

    private void Awake()
    {
        interactionManager = GetComponent<InteractionManager>();
    }

    private void Update()
    {
        if (interactionManager.score >= 20)
        {
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
    }
}
