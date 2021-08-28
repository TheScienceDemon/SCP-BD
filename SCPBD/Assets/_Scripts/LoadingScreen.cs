using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Image loadingScreenImage;
    [SerializeField] Sprite loadingScreenSprite;
    [SerializeField] Slider progressBarSlider;
    [SerializeField] TMP_Text loadingScreenText;
    [SerializeField] [TextArea] string loadingScreenText1;
    [SerializeField] [TextArea] string loadingScreenText2;
    [SerializeField] [TextArea] string loadingScreenText3;

    void OnEnable()
    {
        loadingScreenImage.sprite = loadingScreenSprite;
        loadingScreenImage.SetNativeSize();
    }

    void FixedUpdate()
    {
        if (progressBarSlider.value < .33f)
            loadingScreenText.text = loadingScreenText1;
        if (progressBarSlider.value > .33f)
            loadingScreenText.text = loadingScreenText2;
        if (progressBarSlider.value > .66f)
            loadingScreenText.text = loadingScreenText3;
    }
}
