using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class UserInterfaceMultiplayer : MonoBehaviour
{
    public static UserInterfaceMultiplayer Singleton { get; private set; }

    [Header("Health")]
    public Slider healthSlider;
    public TMP_Text healthText;

    [Header("Stamina")]
    public Slider staminaSlider;
    public TMP_Text staminaText;

    [Header("FPS and Ping")]
    [SerializeField] TMP_Text PingAndFpsText;
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
        //healthText.text = healthSlider.value.ToString() + "%";
        //staminaText.text = staminaSlider.value.ToString() + "%";

        FpsValue += (Time.deltaTime - FpsValue) * .1f;
        float fps = 1.0f / FpsValue;
        PingAndFpsText.text = Mathf.Ceil(fps).ToString() + "FPS" +
            "\n" + NetworkTime.rtt.ToString("F0") + " ms";
    }
}
