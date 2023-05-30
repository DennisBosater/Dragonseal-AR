using UnityEngine;

public class ActivateAfterDelay : MonoBehaviour
{
    public GameObject objectToActivate;
    public float delay = 3f;

    private void Start()
    {
        Invoke("ActivateObject", delay);
    }

    private void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}