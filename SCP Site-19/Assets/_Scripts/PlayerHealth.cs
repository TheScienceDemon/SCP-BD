using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Slider HP_Slider;
    public TMP_Text HP_Text;
    public float maxHP;
    private float currentHP;
    public bool useUI;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (useUI)
        {
            HP_Slider.value = currentHP;
            HP_Text.text = currentHP.ToString("F0") + "%";
        }
    }

    public void TakingDamage(float amount)
    {
        currentHP -= amount;
        if (currentHP <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
