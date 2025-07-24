using UnityEngine;

public class AsteroidFloat : MonoBehaviour
{
    public float MinSpeed = 0.5f;
    public float MaxSpeed = 2.0f;
    public float RotationSpeed = 30f;
    public Vector3 MoveDirection;

    private float _moveSpeed;

    void Start()
    {
        // Randomize direction and speed
        MoveDirection = Random.onUnitSphere; // random 3D direction
        _moveSpeed = Random.Range(MinSpeed, MaxSpeed);

        // Optionally, rotate asteroid randomly at start
        transform.rotation = Random.rotation;
    }

    void Update()
    {
        // Move in assigned direction
        transform.position += MoveDirection * _moveSpeed * Time.deltaTime;

        // Add some rotation
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }
}
