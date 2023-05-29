using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;

using newInputTouch = UnityEngine.InputSystem.EnhancedTouch;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject dragonHitVFX;

    public TextMeshProUGUI text;

    int score;

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
        Vector3 screenPos = new Vector3(obj.screenPosition.x, obj.screenPosition.y, Camera.main.nearClipPlane);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hitinfo, 1000f))
        {
            if (hitinfo.transform.tag == "Dragon")
            {
                //Instantiate(dragonHitVFX, hitinfo.transform.position, hitinfo.transform.rotation);
                //Destroy(dragonHitVFX, 1);

                ChangeScore(1);

                Destroy(hitinfo.transform.gameObject);
            }
        }
    }

    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
        text.text = score.ToString();
    }
}
