using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// NEW ///
/// För hantering av finger touch
using UnityEngine.InputSystem.EnhancedTouch;

/// Skapa en referens till sökvägen för EnhancedTouch
using newInputTouch = UnityEngine.InputSystem.EnhancedTouch;

public class TapToPlace : MonoBehaviour
{
    //[SerializeField]
    //Private GameObject objectToPlace;

    //private GameObject spawnedObject;

    [SerializeField]
    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnEnable()
    {
        newInputTouch.Touch.onFingerDown += Touch_onFingerDown;
    }

    private void OnDisable()
    {
        newInputTouch.Touch.onFingerDown -= Touch_onFingerDown;
    }

    private void Touch_onFingerDown(Finger obj)
    {
        if (raycastManager.Raycast(obj.screenPosition, hitResults, TrackableType.Planes))
        {
            Pose pose = hitResults[0].pose;

            /*if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace, pose.position, pose.rotation);
                spawnedObject.SetActive(true);
            }*/
        }
    }
}