using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public Slider healthSlider;
    [SerializeField] TMP_Text healthText;
    public Slider staminaSlider;
    [SerializeField] TMP_Text staminaText;
    [SerializeField] TMP_Text FpsText;
    float FpsValue;

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
