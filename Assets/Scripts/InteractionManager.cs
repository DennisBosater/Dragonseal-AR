using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch; // För hantering av finger touch
using TMPro;

using newInputTouch = UnityEngine.InputSystem.EnhancedTouch; // Skapa en referens till sökvägen för EnhancedTouch

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
        //// gör er interaktion här!
        // Konvertera över skärmpositionen vi tryckte på , på mobilens skärm till en Vector3 , genom att komplettera med near clip plane värdet.
        // near clip plane värdet syftar till det närmaste planet för kameran som ligger närmast mobilens skärm. 
        Vector3 screenPos = new Vector3(obj.screenPosition.x, obj.screenPosition.y, Camera.main.nearClipPlane);

        // Här utförs att vi skapar en raystråle från skärmens position
        // som vi riktas/pekar in i 3D världen 
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        // Kolla då om denna raystråle träffar något objekt som har en kollisionobjekt kopplat till sig. 
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
