using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

#pragma warning disable IDE0044
public class Settings : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] TMP_Dropdown textureResolutionDropdown;
    [SerializeField] Toggle anisotropicTexturesToggle;
    [SerializeField] TMP_Dropdown antiAliasingDropdown;
    [SerializeField] TMP_Dropdown shadowsDropdown;
    [SerializeField] Slider shadowDistanceSlider;
    [SerializeField] TMP_Text shadowDistanceValueText;
    [SerializeField] Toggle vSyncToggle;
    Resolution[] resolutionArray;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown fullscreenModeDropdown;
    [SerializeField] PostProcessProfile postProcessProfile;
    AmbientOcclusion ao;
    MotionBlur mb;
    Vignette v;
    [SerializeField] Toggle ambientOcclusionToggle;
    [SerializeField] Toggle motionBlurToggle;
    [SerializeField] Toggle vignetteToggle;

    [Space]

    [Header("Audio")]
    [SerializeField] AudioMixer mainMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] TMP_Text musicSliderValueText;
    [SerializeField] Slider soundSlider;
    [SerializeField] TMP_Text soundSliderValueText;

    [Header("Other")]
    [SerializeField] TMP_Dropdown localizationDropdown;

    // Start is called before the first frame update
    void Start()
    {
        RefreshValues();
    }

    void RefreshValues()
    {
        // Graphics
        textureResolutionDropdown.value = QualitySettings.masterTextureLimit;
        textureResolutionDropdown.RefreshShownValue();

        bool AnisotropicToBool(AnisotropicFiltering af)
        {
            switch (af)
            {
                case AnisotropicFiltering.Disable:
                    return false;
                case AnisotropicFiltering.Enable:
                    return true;
                case AnisotropicFiltering.ForceEnable:
                    return true;
                default:
                    Debug.LogError("Anisotropic Textures Setting failed! using switch Standard");
                    QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                    return false;
            }
        }
        anisotropicTexturesToggle.isOn = AnisotropicToBool(QualitySettings.anisotropicFiltering);

        int AntiAliasingToInt(int i)
        {
            switch (i)
            {
                case 0:
                    return 0;
                case 2:
                    return 1;
                case 4:
                    return 2;
                case 8:
                    return 3;
                default:
                    Debug.LogError("Anti Aliasing Setting failed! using switch Standard");
                    QualitySettings.antiAliasing = 0;
                    return 0;
            }
        }
        antiAliasingDropdown.value = AntiAliasingToInt(QualitySettings.antiAliasing);
        antiAliasingDropdown.RefreshShownValue();

        shadowsDropdown.value = (int)QualitySettings.shadows;
        shadowsDropdown.RefreshShownValue();

        shadowDistanceSlider.value = QualitySettings.shadowDistance;
        shadowDistanceValueText.text = QualitySettings.shadowDistance.ToString("F0");

        bool VSyncToBool(int vSyncCount)
        {
            switch (vSyncCount)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                case 2:
                    return true;
                default:
                    Debug.LogError("VSync Setting failed! using switch Standard");
                    QualitySettings.vSyncCount = 0;
                    return false;
            }
        }
        vSyncToggle.isOn = VSyncToBool(QualitySettings.vSyncCount);

        resolutionDropdown.ClearOptions();
        resolutionArray = Screen.resolutions;
        List<string> resolutionOptions = new List<string>();
        int currentIndex = 0;
        for (int i = 0; i < resolutionArray.Length; i++)
        {
            string resolutionOption = resolutionArray[i].width +
                " x " + resolutionArray[i].height +
                " @" + resolutionArray[i].refreshRate;
            resolutionOptions.Add(resolutionOption);
            if (resolutionArray[i].width == Screen.currentResolution.width &&
                resolutionArray[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenModeDropdown.value = (int) Screen.fullScreenMode;
        fullscreenModeDropdown.RefreshShownValue();

        ao = postProcessProfile.GetSetting<AmbientOcclusion>();
        mb = postProcessProfile.GetSetting<MotionBlur>();
        v = postProcessProfile.GetSetting<Vignette>();
        ambientOcclusionToggle.isOn = ao.active;
        motionBlurToggle.isOn = mb.active;
        vignetteToggle.isOn = v.active;

        // Audio
        if (PlayerPrefs.HasKey("MusicSliderValue"))
            musicSlider.value = PlayerPrefs.GetFloat("MusicSliderValue");

        musicSliderValueText.text = (musicSlider.value * 100).ToString("F0") + "%";
        mainMixer.SetFloat("MusicGroup", Mathf.Log10(musicSlider.value) * 20);

        if (PlayerPrefs.HasKey("SoundSliderValue"))
            soundSlider.value = PlayerPrefs.GetFloat("SoundSliderValue");

        mainMixer.SetFloat("SoundGroup", Mathf.Log10(soundSlider.value) * 20);
        soundSliderValueText.text = (soundSlider.value * 100).ToString("F0") + "%";

        // Other
        StartCoroutine(GenerateLocaleDropdownOptions());
    }

    #region Graphics
    public void SetTextureResolution(int textureResolutionIndex)
    {
        QualitySettings.masterTextureLimit = textureResolutionIndex;
    }

    public void SetAnisotropicTextures(bool useAnisotropicTextures)
    {
        AnisotropicFiltering BoolToAnisotropic(bool b)
        {
            return b ? AnisotropicFiltering.ForceEnable : AnisotropicFiltering.Disable;
        }

        QualitySettings.anisotropicFiltering = BoolToAnisotropic(useAnisotropicTextures);
    }

    public void SetAntiAliasing(int antiAliasingIndex)
    {
        switch (antiAliasingIndex)
        {
            case 0:
                QualitySettings.antiAliasing = 0;
                break;
            case 1:
                QualitySettings.antiAliasing = 2;
                break;
            case 2:
                QualitySettings.antiAliasing = 4;
                break;
            case 3:
                QualitySettings.antiAliasing = 8;
                break;
            default:
                QualitySettings.antiAliasing = 0;
                antiAliasingDropdown.value = 0;
                Debug.LogError("Anti Aliasing value is switch default!");
                break;
        }
    }

    public void SetShadows(int shadowIndex)
    {
        QualitySettings.shadows = (ShadowQuality) shadowIndex;
    }

    public void SetShadowResolution(int shadowResolutionIndex)
    {
        QualitySettings.shadowResolution = (ShadowResolution) shadowResolutionIndex;
    }

    public void SetShadowDistance(float shadowDistance)
    {
        QualitySettings.shadowDistance = shadowDistance;
        shadowDistanceValueText.text = shadowDistance.ToString();
    }

    public void SetVSync(bool useVSync)
    {
        int boolToVSync(bool b)
        {
            return b ? 1 : 0;
        }

        QualitySettings.vSyncCount = boolToVSync(useVSync);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionArray[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,
            Screen.fullScreenMode, resolution.refreshRate);
    }

    public void SetFullscreenMode(int fullscreenModeIndex)
    {
        Screen.fullScreenMode = (FullScreenMode) fullscreenModeIndex;
    }

    public void SetAmbientOcclusion(bool useAO)
    {
        ao.active = useAO;
    }

    public void SetMotionBlur(bool useMB)
    {
        mb.active = useMB;
    }

    public void SetVignette(bool useV)
    {
        v.active = useV;
    }
    #endregion

    #region Audio
    public void SetVolumeMusic(float music)
    {
        mainMixer.SetFloat("MusicGroup", Mathf.Log10(music) * 20);
        musicSliderValueText.text = (musicSlider.value * 100).ToString("F0") + "%";
        PlayerPrefs.SetFloat("MusicSliderValue", music);
        PlayerPrefs.Save();
    }

    public void SetVolumeSound(float sound)
    {
        mainMixer.SetFloat("SoundGroup", Mathf.Log10(sound) * 20);
        soundSliderValueText.text = (soundSlider.value * 100).ToString("F0") + "%";
        PlayerPrefs.SetFloat("SoundSliderValue", sound);
        PlayerPrefs.Save();
    }
    #endregion

    #region Other
    IEnumerator GenerateLocaleDropdownOptions()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        // Clear already existing options
        localizationDropdown.ClearOptions();

        // Generate list of available Locales
        var options = new List<TMP_Dropdown.OptionData>();
        int selected = 0;
        for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;
            options.Add(new TMP_Dropdown.OptionData(locale.name));
        }
        localizationDropdown.options = options;

        localizationDropdown.value = selected;
    }

    public void SetLanguage(int languageIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }
    #endregion
}
