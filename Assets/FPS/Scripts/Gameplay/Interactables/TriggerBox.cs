using UnityEngine;

public class TriggerDoorMove : MonoBehaviour
{
    public GameObject door;                // Reference to the door
    public Transform targetPosition;       // The position the door moves to
    public float moveSpeed = 2f;           // Movement speed

    private bool shouldMove = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMove = true;
        }
    }

    void Update()
    {
        if (shouldMove && door != null && targetPosition != null)
        {
            door.transform.position = Vector3.MoveTowards(
                door.transform.position,
                targetPosition.position,
                moveSpeed * Time.deltaTime
            );
        }
    }
}