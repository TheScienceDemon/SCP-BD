using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public static UserInterface Singleton { get; private set; }

    [Header("Health")]
    public Slider healthSlider;
    public TMP_Text healthText;

    [Header("Stamina")]
    public Slider staminaSlider;
    public TMP_Text staminaText;

    [Header("FPS")]
    [SerializeField] TMP_Text FpsText;
    float FpsValue;

    [Header("Clickable Screen")]
    public Image clickableScreenImage;

    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        FpsValue += (Time.deltaTime - FpsValue) * .1f;
        float fps = 1.0f / FpsValue;
        FpsText.text = Mathf.Ceil(fps).ToString() + "FPS";
    }
}
