using UnityEngine;
using System.Collections;

public class TriggerDoorMove2 : MonoBehaviour
{
    [System.Serializable]
    public class DoorData
    {
        public GameObject door;             // The door GameObject
        public Transform targetPosition;    // The target position it moves to
        public float moveSpeed = 2f;        // Movement speed
    }

    public DoorData[] doors;                // Array of doors
    public float delayBetweenDoors = 3f;    // Delay in seconds between doors

    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(OpenDoorsSequentially());
        }
    }

    IEnumerator OpenDoorsSequentially()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            StartCoroutine(MoveDoor(doors[i]));

            // Wait before opening the next door
            if (i == 0)
            {
                yield return new WaitForSeconds(delayBetweenDoors); // fixed delay after first door
            }
            else
            {
                // Wait until door is fully open before waiting delay and opening the next
                yield return new WaitUntil(() =>
                    Vector3.Distance(doors[i].door.transform.position, doors[i].targetPosition.position) < 0.01f);
                yield return new WaitForSeconds(delayBetweenDoors);
            }
        }
    }

    IEnumerator MoveDoor(DoorData doorData)
    {
        while (Vector3.Distance(doorData.door.transform.position, doorData.targetPosition.position) > 0.01f)
        {
            doorData.door.transform.position = Vector3.MoveTowards(
                doorData.door.transform.position,
                doorData.targetPosition.position,
                doorData.moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        // Snap to final position to avoid jitter
        doorData.door.transform.position = doorData.targetPosition.position;
    }
}