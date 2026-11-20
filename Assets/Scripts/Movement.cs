using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 5f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float rotationFactor = 5f;
    [SerializeField] float rotationFactorY = 5f;
    [SerializeField] float rotationSpeed = 5f;
    Vector2 movement;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float xRaw = transform.localPosition.x + xOffset;
        float yRaw = transform.localPosition.y + yOffset;
        float xFinal = Mathf.Clamp(xRaw, -xRange, xRange);
        float yFinal = Mathf.Clamp(yRaw, -yRange, yRange);
        //transform.localPosition = new Vector3(transform.localPosition.x + xOffset, 0f, 0f);
        transform.localPosition = new Vector3(xFinal, yFinal, 0f);
    }

    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(rotationFactorY * movement.y, 0f, rotationFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnMove(InputValue value)
    {
        //Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
}
