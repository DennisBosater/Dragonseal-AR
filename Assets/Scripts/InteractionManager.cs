using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch; // F�r hantering av finger touch
using TMPro;

using newInputTouch = UnityEngine.InputSystem.EnhancedTouch; // Skapa en referens till s�kv�gen f�r EnhancedTouch

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
        //// g�r er interaktion h�r!
        // Konvertera �ver sk�rmpositionen vi tryckte p� , p� mobilens sk�rm till en Vector3 , genom att komplettera med near clip plane v�rdet.
        // near clip plane v�rdet syftar till det n�rmaste planet f�r kameran som ligger n�rmast mobilens sk�rm. 
        Vector3 screenPos = new Vector3(obj.screenPosition.x, obj.screenPosition.y, Camera.main.nearClipPlane);

        // H�r utf�rs att vi skapar en raystr�le fr�n sk�rmens position
        // som vi riktas/pekar in i 3D v�rlden 
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        // Kolla d� om denna raystr�le tr�ffar n�got objekt som har en kollisionobjekt kopplat till sig. 
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
