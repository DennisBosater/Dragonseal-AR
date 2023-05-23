using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFlight : MonoBehaviour
{
    private float flightAngle;
    private float flightSpeed;

    private void Update()
    {
        // Move the dragon in the specified flight direction and speed
        Vector3 flightDirection = Quaternion.Euler(flightAngle, transform.eulerAngles.y, 0f) * Vector3.forward;
        transform.position += flightDirection * flightSpeed * Time.deltaTime;
    }

    public void SetFlightBehavior(float angle, float speed)
    {
        flightAngle = angle;
        flightSpeed = speed;
    }
}
