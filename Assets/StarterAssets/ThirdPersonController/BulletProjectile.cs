using UnityEngine;
using Unity.FPS.Game; // needed to access Health script

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    [SerializeField] private float damage = 10f;

    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        bulletRigidbody.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if it hit a damagable target
        BulletTarget targetMarker = other.GetComponent<BulletTarget>();
        if (targetMarker != null)
        {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);

            //Apply damage if target has Health script
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage, gameObject); //pass the bullet or shooter object
            }
        }
        else
        {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }

        /* Old version of the script, without the health
        if (other.GetComponent<BulletTarget>() != null)
        {
            //Hit target
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else
        {
            //Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);

        }
        */

        Destroy(gameObject);
    }
}

   
