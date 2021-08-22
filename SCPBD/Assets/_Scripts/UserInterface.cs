using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [Header("Health")]
    public Slider healthSlider;
    [SerializeField] TMP_Text healthText;

    [Header("Stamina")]
    public Slider staminaSlider;
    [SerializeField] TMP_Text staminaText;

    [Header("FPS")]
    [SerializeField] TMP_Text FpsText;
    float FpsValue;

    [Header("Clickable Screen")]
    public Image clickableScreenImage;

    // Update is called once per frame
    void Update()
    {
        //healthText.text = healthSlider.value.ToString() + "%";
        //staminaText.text = staminaSlider.value.ToString() + "%";
        FpsValue += (Time.deltaTime - FpsValue) * .1f;
        float fps = 1.0f / FpsValue;
        FpsText.text = Mathf.Ceil(fps).ToString() + "FPS";
    }
}
