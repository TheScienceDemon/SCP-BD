using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Slider healthSlider;

    float lerpedHealth;

    // Start is called before the first frame update
    void Start()
    {
        SetupHealth(playerStats.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        lerpedHealth = Mathf.Lerp(lerpedHealth, playerStats.currentHealth, Time.deltaTime * 3f);
        healthSlider.value = lerpedHealth;
    }

    void SetupHealth(int newMaxHealth)
    {
        lerpedHealth = newMaxHealth;
        healthSlider.maxValue = newMaxHealth;
        SetHealth(newMaxHealth);
    }

    public void SetHealth(int newHealth)
    {
        playerStats.currentHealth = newHealth;
    }
}
