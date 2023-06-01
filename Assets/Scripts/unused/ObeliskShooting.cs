using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingInterval = 2f;

    private GameObject closestDragon;
    private float timeSinceLastShot;

    private void Start()
    {
        // Start shooting immediately
        timeSinceLastShot = shootingInterval;
    }

    private void Update()
    {
        // Find the closest Dragon GameObject
        FindClosestDragon();

        // Update the shooting timer
        timeSinceLastShot += Time.deltaTime;

        // Shoot at the closest Dragon if enough time has passed
        if (closestDragon != null && timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    private void FindClosestDragon()
    {
        GameObject[] dragons = GameObject.FindGameObjectsWithTag("Dragon");
        float closestDistance = Mathf.Infinity;
        closestDragon = null;

        foreach (GameObject dragon in dragons)
        {
            float distance = Vector3.Distance(transform.position, dragon.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestDragon = dragon;
            }
        }
    }

    private void Shoot()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction towards the closest Dragon, taking into account its movement
        Vector3 targetPosition = closestDragon.transform.position + closestDragon.GetComponent<Rigidbody>().velocity;
        Vector3 shootDirection = (targetPosition - transform.position).normalized;

        // Set the initial velocity of the projectile to hit the moving target
        projectile.GetComponent<Rigidbody>().velocity = shootDirection * projectile.GetComponent<ObeliskProjectileMovement>().speed;
    }
}
