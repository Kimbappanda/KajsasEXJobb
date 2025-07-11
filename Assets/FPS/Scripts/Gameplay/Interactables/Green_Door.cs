using UnityEngine;

public class MoveObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToMove; // Assign in inspector
    public Vector3 targetPosition;  // New position to move to
    public float moveSpeed = 2f;    // Speed of movement

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
        if (shouldMove && objectToMove != null)
        {
            objectToMove.transform.position = Vector3.MoveTowards(
                objectToMove.transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
        }
    }
}
