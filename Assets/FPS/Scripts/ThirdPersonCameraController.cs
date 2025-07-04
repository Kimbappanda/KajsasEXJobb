using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform player;           // Player root (for yaw)
    public Transform cameraPivot;      // Pivot for pitch (child of player)
    public float sensitivity = 2f;
    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float pitch = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        Debug.Log($"MouseX: {mouseX}, MouseY: {mouseY}");

        // Rotate player horizontally (yaw)
        player.Rotate(Vector3.up, mouseX);

        // Rotate camera pivot vertically (pitch)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0, 0);

    }
}

