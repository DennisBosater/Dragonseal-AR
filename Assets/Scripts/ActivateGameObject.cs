using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public GameObject objectToActivate;

    public void Activate()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}