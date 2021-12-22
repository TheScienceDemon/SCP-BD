using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        SetupHealth(playerStats.maxHealth);
    }

    void SetupHealth(int newMaxHealth)
    {
        healthSlider.maxValue = newMaxHealth;
        SetHealth(newMaxHealth);
    }

    public void SetHealth(int newHealth)
    {
        playerStats.currentHealth = newHealth;

        while (healthSlider.value != newHealth)
            healthSlider.value = Mathf.Lerp(healthSlider.value, newHealth, Time.deltaTime * 3f);
    }
}
