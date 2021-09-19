using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    [Header("Keycard")]
    public StructManager.KeycardAccessLevel keycardAccessLevel;

    [Header("Health & Stamina")]
    public float maxHealth;
    public float currentHealth;
    public float maxStamina;
    public float currentStamina; 

    UserInterface ui;
    FirstPersonController fpsController;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        ui = UserInterface.Singleton;

        ui.healthSlider.maxValue = maxHealth;
        currentHealth = maxHealth;

        ui.staminaSlider.maxValue = maxStamina;
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ui.staminaSlider.value = currentStamina;
        ui.staminaText.text = currentStamina.ToString("F0") + "%";
        ui.healthSlider.value = currentHealth;
        ui.healthText.text = currentHealth.ToString("F0") + "%";
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
