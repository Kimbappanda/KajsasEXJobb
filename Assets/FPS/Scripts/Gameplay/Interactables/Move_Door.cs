using UnityEngine;

public class Move_Door : MonoBehaviour
{
    public Transform _target; // Object to move towards
    public float _speed; // Number of units to move each second

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //moves this object towards _target by _speed units each second
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime); 
    }
}
