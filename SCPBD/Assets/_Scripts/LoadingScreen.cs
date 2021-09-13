using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] Slider progressBarSlider;
    [SerializeField] TMP_Text loadingScreenText;
    [SerializeField] Image loadingScreenImage;
    [SerializeField] LoadingScreens[] loadingScreens;
    string loadingScreenText1;
    string loadingScreenText2;
    string loadingScreenText3;

    int loadingScreenIndex;

    void OnEnable()
    {
        ApplyLoadingScreen();
    }

    void ApplyLoadingScreen()
    {
        loadingScreenIndex = Random.Range(0, loadingScreens.Length);

        loadingScreenImage.sprite = loadingScreens[loadingScreenIndex].loadingScreenSprite;
        loadingScreenImage.SetNativeSize();

        loadingScreenText1 = loadingScreens[loadingScreenIndex].loadingScreenText1;
        loadingScreenText2 = loadingScreens[loadingScreenIndex].loadingScreenText2;
        loadingScreenText3 = loadingScreens[loadingScreenIndex].loadingScreenText3;
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

    [System.Serializable]
    public struct LoadingScreens
    {
        public string label;
        public Sprite loadingScreenSprite;
        [TextArea(0, int.MaxValue)] public string loadingScreenText1;
        [TextArea(0, int.MaxValue)] public string loadingScreenText2;
        [TextArea(0, int.MaxValue)] public string loadingScreenText3;
    }
}
