using Unity.FPS.Game;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public StarterAssets.ThirdPersonController ThirdPerson;

    // Add a Health reference for convenience
    public Unity.FPS.Game.Health Health;

    void Start()
    {
        Health = GetComponent<Unity.FPS.Game.Health>();
    }

    // This method is called by the pickup script
    public void OnHealthPickup(float healAmount)
    {
        if (Health != null && Health.CanPickup())
        {
            Health.Heal(healAmount);
            Debug.Log("Healed by pickup!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            var health = GetComponent<Health>();
            if (health != null)
            {
                health.Heal(10f);
                Debug.Log("Healed by 10");
            }
        }
    }

}
