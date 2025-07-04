using UnityEngine;

public class CameraPitchTest : MonoBehaviour
{
    public float sensitivity = 2f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float pitch = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }
}
