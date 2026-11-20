using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform trackingTarget;
    [SerializeField] private float targetDistance = 100f;
    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFire();
        TrackMouse();
        TrackTarget();
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        foreach (ParticleSystem laser in lasers)
        {
            Vector3 direction = trackingTarget.position - this.transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            laser.transform.rotation = lookRotation;
        }
    }

    private void TrackTarget()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        trackingTarget.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void TrackMouse()
    {
        crosshair.position = Input.mousePosition;
    }

    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
       // Debug.Log("Player weapon fired!");
    }

    private void ProcessFire()
    {
        foreach (ParticleSystem laser in lasers)
        {
            var emission = laser.emission;
            emission.enabled = isFiring;
        }
    }
}
