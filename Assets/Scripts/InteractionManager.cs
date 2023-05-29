using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;

using newInputTouch = UnityEngine.InputSystem.EnhancedTouch;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject dragonHitVFX;
    [SerializeField] private AudioSource dragonHitSound;

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
                ChangeScore(1);

                Vector3 spawnPosition = hitinfo.transform.position + new Vector3(0f, 0.025f, 0f);
                GameObject vfx = Instantiate(dragonHitVFX, spawnPosition, Quaternion.identity);

                if (dragonHitSound != null)
                    dragonHitSound.Play();

                Destroy(vfx, 1f); // Destroy the visual effect after 1 second
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