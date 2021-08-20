using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{
    [Header("Keycard")]
    public int keycardLevel;

    [Header("Health & Stamina")]
    [SerializeField] float Health;
    [Range(0f, 100f)] public float Stamina;


    UserInterface ui;
    FirstPersonController fpsController;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        ui = FindObjectOfType<UserInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.staminaSlider.value = Stamina;
    }
}
