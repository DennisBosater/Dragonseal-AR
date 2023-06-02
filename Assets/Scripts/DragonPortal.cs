/*using UnityEngine;

public class DragonPortal : MonoBehaviour
{
    public GameObject dragonPrefab;
    public float initialSpawnDelay = 3f; // Initial delay before first dragon spawn
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 2.5f;
    public float spawnRateIncrease = 0.1f; // Rate at which the spawn rate increases over time

    private float elapsedTime = 0f; // Time elapsed since the start of the game
    private float lastSpawnTime = 0f; // Time of the last dragon spawn
    private bool isCoroutineRunning = false; // Track whether the coroutine is running

    private void OnEnable()
    {
        if (!isCoroutineRunning)
        {
            StartCoroutine(SpawnDragons());
            isCoroutineRunning = true;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnDragons());
        isCoroutineRunning = false;
    }

    private void Start()
    {
        // Start the coroutine to spawn dragons
        StartCoroutine(SpawnDragons());
        isCoroutineRunning = true;
    }

    private System.Collections.IEnumerator SpawnDragons()
    {
        // Initial delay before the first dragon spawn
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            // Generate random values for dragon behavior
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay) - elapsedTime * spawnRateIncrease;
            float flightAngle = Random.Range(-20f, -45f);
            float flightSpeed = Random.Range(0.08f, 0.16f);
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Check if enough time has passed since the last spawn
            if (Time.time - lastSpawnTime >= 0.5f)
            {
                // Instantiate a dragon prefab
                GameObject dragon = Instantiate(dragonPrefab, transform.position, randomRotation);

                // Set the dragon's flight behavior
                DragonFlight dragonFlight = dragon.GetComponent<DragonFlight>();
                if (dragonFlight != null)
                {
                    dragonFlight.SetFlightBehavior(flightAngle, flightSpeed);
                }

                // Destroy the dragon after 6 seconds
                Destroy(dragon, 6f);

                // Update the last spawn time
                lastSpawnTime = Time.time;
            }

            // Wait for the specified spawn delay before checking for the next spawn opportunity
            yield return new WaitForSeconds(spawnDelay);

            // Update elapsed time
            elapsedTime += spawnDelay;
        }
    }
}*/

using UnityEngine;

public class DragonPortal : MonoBehaviour
{
    public GameObject dragonPrefab;
    public float initialSpawnDelay = 3f; // Initial delay before first dragon spawn
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 2.5f;
    public float spawnRateIncrease = 0.1f; // Rate at which the spawn rate increases over time
    private float elapsedTime = 0f; // Time elapsed since the start of the game
    private float lastSpawnTime = 0f; // Time of the last dragon spawn
    private bool isCoroutineRunning = false; // Track whether the coroutine is running
    
    private float dragonSpeedModifier = 1f; // Speed modifier for spawning dragons

    private void OnEnable()
    {
        if (!isCoroutineRunning)
        {
            StartCoroutine(SpawnDragons());
            isCoroutineRunning = true;
        }
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnDragons());
        isCoroutineRunning = false;
    }

    private void Start()
    {
        // Start the coroutine to spawn dragons
        StartCoroutine(SpawnDragons());
        isCoroutineRunning = true;
    }

    private System.Collections.IEnumerator SpawnDragons()
    {
        // Initial delay before the first dragon spawn
        yield return new WaitForSeconds(initialSpawnDelay);

        while (true)
        {
            // Generate random values for dragon behavior
            float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay) - elapsedTime * spawnRateIncrease;
            float flightAngle = Random.Range(-20f, -45f);
            float flightSpeed = Random.Range(0.08f, 0.16f) * dragonSpeedModifier; // Apply speed modifier if obelisk is active
            Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // Check if enough time has passed since the last spawn
            if (Time.time - lastSpawnTime >= 0.5f)
            {
                // Instantiate a dragon prefab
                GameObject dragon = Instantiate(dragonPrefab, transform.position, randomRotation);

                // Set the dragon's flight behavior
                DragonFlight dragonFlight = dragon.GetComponent<DragonFlight>();
                if (dragonFlight != null)
                {
                    dragonFlight.SetFlightBehavior(flightAngle, flightSpeed);
                }

                // Destroy the dragon after 6 seconds
                Destroy(dragon, 6f);

                // Update the last spawn time
                lastSpawnTime = Time.time;
            }

            // Wait for the specified spawn delay before checking for the next spawn opportunity
            yield return new WaitForSeconds(spawnDelay);

            // Update elapsed time
            elapsedTime += spawnDelay;
        }
    }

    private void Update()
    {
        // Check if any gameobject with the "Obelisk" tag is active in the scene
        GameObject[] obelisks = GameObject.FindGameObjectsWithTag("Obelisk");
        bool obeliskActive = false;
        foreach (GameObject obelisk in obelisks)
        {
            if (obelisk.activeInHierarchy)
            {
                obeliskActive = true;
                break;
            }
        }

        // Update the dragon speed modifier based on the obelisk's active state
        if (obeliskActive)
        {
            dragonSpeedModifier = 0.5f; // Reduce speed by 50%
        }
        else
        {
            dragonSpeedModifier = 1f; // Reset speed to normal
        }
    }
}


