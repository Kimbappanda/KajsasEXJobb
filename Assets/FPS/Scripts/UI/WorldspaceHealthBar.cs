using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class WorldspaceHealthBar : MonoBehaviour
    {
        [Tooltip("Health component to track")]
        public Health Health;

        [Tooltip("Image component displaying health left")]
        public Image HealthBarImage;

        [Tooltip("The floating healthbar pivot transform")]
        public Transform HealthBarPivot;

        [Tooltip("Whether the health bar is visible when at full health or not")]
        public bool HideFullHealthBar = true;



        void Update()
        {
            if (Health == null)
            {
                Debug.LogWarning("Health is null");
                return;
            }

            float healthRatio = Health.CurrentHealth / Health.MaxHealth;
            Debug.Log($"Health ratio: {healthRatio}");

            // Update health bar fill
            if (HealthBarImage != null)
                HealthBarImage.fillAmount = healthRatio;

            // Rotate to face camera
            if (HealthBarPivot != null)
                HealthBarPivot.LookAt(Camera.main.transform.position);

            // Optionally hide health bar at full health
            if (HideFullHealthBar && HealthBarPivot != null)
                HealthBarPivot.gameObject.SetActive(healthRatio != 1);
            
        }
    }
}
