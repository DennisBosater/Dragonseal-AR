using UnityEngine;

public class DragonPortal : MonoBehaviour
{
    public GameObject dragonPrefab;
    public float initialSpawnDelay = 3f; // Initial delay before first dragon spawn
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 4f;
    public float spawnRateIncrease = 0.05f; // Rate at which the spawn rate increases over time
    public float maxDistanceFromPortal = 20f; // Maximum distance from portal before deletion

    private float elapsedTime = 0f; // Time elapsed since the start of the game
    private float lastSpawnTime = 0f; // Time of the last dragon spawn

    private void Start()
    {
        // Start the coroutine to spawn dragons
        StartCoroutine(SpawnDragons());
    }

    private System.Collections.IEnumerator SpawnDragons()
    {
        // Initial delay before the first dragon spawn
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            // Check if any dragons are too far away and delete them
            GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");
            foreach (GameObject dragonPrefab in dragons)
            {
                if (Vector3.Distance(transform.position, dragonPrefab.transform.position) > maxDistanceFromPortal)
                {
                    Destroy(dragonPrefab);
                }
            }

            // Generate random values for dragon behavior
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay) - elapsedTime * spawnRateIncrease;
            float flightAngle = Random.Range(-20f, -45f);
            float flightSpeed = Random.Range(1.5f, 3.5f);
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Check if enough time has passed since the last spawn
            if (Time.time - lastSpawnTime >= 0.25f)
            {
                // Instantiate a dragon prefab
                GameObject dragon = Instantiate(dragonPrefab, transform.position, randomRotation);

                // Set the dragon's flight behavior
                DragonFlight dragonFlight = dragon.GetComponent<DragonFlight>();
                if (dragonFlight != null)
                {
                    dragonFlight.SetFlightBehavior(flightAngle, flightSpeed);
                }

                // Update the last spawn time
                lastSpawnTime = Time.time;
            }

            // Wait for the specified spawn delay before checking for the next spawn opportunity
            yield return new WaitForSeconds(spawnDelay);

            // Update elapsed time
            elapsedTime += spawnDelay;
        }
    }
}
