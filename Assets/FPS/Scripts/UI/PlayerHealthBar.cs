using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [Tooltip("Image component displaying current health")]
        public Image HealthFillImage;

        [Tooltip("Transform of the cylinder to scale with health")]
        public Transform HealthCylinderTransform;

        [Tooltip("Renderer of the cylinder for color changes")]
        public Renderer HealthCylinderRenderer;


        public Color fullHealthColor = Color.green;
        public Color midHealthColor = Color.yellow;
        public Color lowHealthColor = Color.red;

        [Header("Health Color Thresholds")]
        [Range(0f, 1f)] public float YellowThreshold = 0.8f;
        [Range(0f, 1f)] public float RedThreshold = 0.4f;

        Health m_PlayerHealth;
        Vector3 m_InitialCylinderScale;

        

        void Start()
        {
            PlayerCharacterController playerCharacterController =
                GameObject.FindFirstObjectByType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(
                playerCharacterController, this);

            m_PlayerHealth = playerCharacterController.GetComponent<Health>();
            DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerHealthBar>(m_PlayerHealth, this,
                playerCharacterController.gameObject);

            if (HealthCylinderTransform != null)
                m_InitialCylinderScale = HealthCylinderTransform.localScale;
        }

        void Update()
        {
            float healthRatio = m_PlayerHealth.CurrentHealth / m_PlayerHealth.MaxHealth;

            // Update UI health bar
            HealthFillImage.fillAmount = healthRatio;

            // Update cylinder scale
            if (HealthCylinderTransform != null)
            {
                Vector3 newScale = m_InitialCylinderScale;
                newScale.y = m_InitialCylinderScale.y * healthRatio;
                HealthCylinderTransform.localScale = newScale;
            }

            // Update cylinder color
            if (HealthCylinderRenderer != null)
            {
                Color newColor;

                if (healthRatio > YellowThreshold)
                {
                    // Green to Yellow
                    float t = Mathf.InverseLerp(1f, YellowThreshold, healthRatio);
                    newColor = Color.Lerp(fullHealthColor, midHealthColor, t);
                }
                else if (healthRatio > RedThreshold)
                {
                    // Yellow to Red
                    float t = Mathf.InverseLerp(YellowThreshold, RedThreshold, healthRatio);
                    newColor = Color.Lerp(midHealthColor, lowHealthColor, t);
                }
                else
                {
                    // Below RedThreshold — fully red
                    newColor = lowHealthColor;
                }

                Material mat = HealthCylinderRenderer.material;

                //Set base color (optional)
                mat.color = newColor;

                //Set emissive color 
                mat.SetColor("_EmissionColor", newColor);

                //Make sure emission is enabled
                mat.EnableKeyword("_EMISSION");
            }
        }
    }
}
