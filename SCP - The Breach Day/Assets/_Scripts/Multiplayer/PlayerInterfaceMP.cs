using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerInterfaceMP : NetworkBehaviour
{
    public static PlayerInterfaceMP Singleton { get; private set; }

    PlayerStatsMP playerStats;
    public Slider healthSlider;
    public Slider staminaSlider;
    public GameObject wholePauseMenuObj;

    [HideInInspector] public float lerpedHealth;
    [HideInInspector] public float lerpedStamina;

    void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (playerStats == null) {
            playerStats = FindObjectOfType<PlayerStatsMP>();
        }

        if (lerpedStamina >= (playerStats.maxStamina - .5f))
        {
            if (staminaSlider.gameObject.activeSelf)
                staminaSlider.gameObject.SetActive(false);
        }
        else
        {
            if (!staminaSlider.gameObject.activeSelf)
                staminaSlider.gameObject.SetActive(true);
        }

        lerpedHealth = Mathf.Lerp(
            lerpedHealth,
            playerStats.currentHealth,
            Time.deltaTime * 3f);

        lerpedStamina = Mathf.Lerp(
            lerpedStamina,
            playerStats.currentStamina,
            Time.deltaTime * 6f);

        healthSlider.value = lerpedHealth;
        staminaSlider.value = lerpedStamina;
    }
}
