using UnityEngine;

public class ObeliskActivation : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject playSFX;
    public GameObject objectToDeactivate;

    private InteractionManager interactionManager;

    private void Awake()
    {
        interactionManager = GetComponent<InteractionManager>();
    }

    private void Update()
    {
        if (interactionManager.score >= 40)
        {
            objectToActivate.SetActive(true);
            playSFX.SetActive(true);
            objectToDeactivate.SetActive(false);
        }
    }
}
