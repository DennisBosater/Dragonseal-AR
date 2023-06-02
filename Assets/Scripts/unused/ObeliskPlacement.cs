using UnityEngine;

public class ObeliskPlacement : MonoBehaviour
{
    public GameObject obeliskPrefab; // Reference to the object to be activated and placed

    private void Start()
    {
        ActivateAndPlace();
    }

    private void ActivateAndPlace()
    {
        // Instantiate the obelisk prefab and place it in the position of the current obelisk
        GameObject newObelisk = Instantiate(obeliskPrefab, transform.position, transform.rotation);

        // Get the parent object
        Transform parent = transform.parent;

        // Deactivate the current obelisk
        gameObject.SetActive(false);

    }
}
