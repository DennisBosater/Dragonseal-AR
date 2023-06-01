using UnityEngine;

public class ObeliskPlacement : MonoBehaviour
{
    public GameObject obeliskPrefab;
    public GameObject obeliskTracking;
    public GameObject markerlessTracking;

    private void OnEnable()
    {
        // Deactivate the two game objects
        obeliskTracking.SetActive(false);
        markerlessTracking.SetActive(false);

        // Activate the target game object
        obeliskPrefab.SetActive(true);

        // Set the position of the target game object to the position of objectToDeactivate1
        obeliskPrefab.transform.position = obeliskTracking.transform.position;
    }
}