using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    FirstPersonController fpsController;
    [SerializeField] Slider StaminaSlider;
    [SerializeField] float Health;
    [Range(0f, 100f)] public float Stamina;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        StaminaSlider.value = Stamina;
    }
}
