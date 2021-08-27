using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] TMP_Dropdown graphicsDropdown;
    Resolution[] resolutionArray;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TMP_Text volumeText;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioClip[] menuAudio;
    [SerializeField] AudioSource menuAudioSource;
    [SerializeField] TMP_Dropdown menuMusicDropdown;
    [SerializeField] TMP_Dropdown languageDropdown;
    [SerializeField] Toggle fullscreenToggle;

    // Start is called before the first frame update
    void Start()
    {
        // Sprach Einstellungen
        StartCoroutine(GenerateLocaleDropdownOptions());
        StartCoroutine(test());

        // Grafik Einstellungen
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        graphicsDropdown.RefreshShownValue();

        // Hauptmenü Musik
        menuMusicDropdown.ClearOptions();
        List<string> musicOptions = new List<string>();

        for (int i = 0; i < menuAudio.Length; i++)
            musicOptions.Add(menuAudio[i].name);

        menuMusicDropdown.AddOptions(musicOptions);
        menuAudioSource.clip = menuAudio[0];
        menuAudioSource.Play();

        // Auflösung
        resolutionDropdown.ClearOptions();
        resolutionArray = Screen.resolutions;
        List<string> resolutionOptions = new List<string>();
        int currentIndex = 0;
        for (int i = 0; i < resolutionArray.Length; i++)
        {
            string resolutionOption = resolutionArray[i].width + " x " + resolutionArray[i].height;
            resolutionOptions.Add(resolutionOption);
            if (resolutionArray[i].width == Screen.currentResolution.width && resolutionArray[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void GetValues()
    {
        GetQualityLevel();
        GetResolution();
        GetVolume();
        GetMenuMusic();
        GetFullscreen();
    }

    IEnumerator GenerateLocaleDropdownOptions()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

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
        languageDropdown.options = options;

        languageDropdown.value = selected;
        //languageDropdown.onValueChanged.AddListener(SetLanguage);
    }

    IEnumerator test()
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }

    void GetQualityLevel()
    {
        graphicsDropdown.value = OptionValues.instance.qualityLevel;
    }

    public void SetQualityLevel(int qualityLevel)
    {
        OptionValues.instance.qualityLevel = qualityLevel;
        QualitySettings.SetQualityLevel(qualityLevel);
        Debug.Log("Qualitätsstufe ist jetzt auf : " + QualitySettings.GetQualityLevel());
    }

    void GetResolution()
    {
        resolutionDropdown.value = OptionValues.instance.resolutionIndex;
    }

    public void SetResolution(int resolutionIndex)
    {
        OptionValues.instance.resolutionIndex = resolutionIndex;
        Resolution resolution = resolutionArray[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Auflösung ist jetzt auf : " + resolution);
    }

    void GetVolume()
    {
        volumeSlider.value = OptionValues.instance.volume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        OptionValues.instance.volume = volume;
        Debug.Log("Volume ist jetzt auf : " + (volume * 100).ToString("F0"));
        volumeText.text = (volume * 100).ToString("F0") + "%";
    }

    void GetMenuMusic()
    {
        menuMusicDropdown.value = OptionValues.instance.menuMusicIndex;
    }

    public void SetMenuMusic(int menuMusicIndex)
    {
        menuAudioSource.clip = menuAudio[menuMusicIndex];
        menuAudioSource.Play();
        OptionValues.instance.menuMusicIndex = menuMusicIndex;
        Debug.Log("Hauptmenumusik ist jetzt : " + menuAudioSource.clip.name);
    }

    public void SetLanguage(int languageIndex)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
    }

    void GetFullscreen()
    {
        fullscreenToggle.isOn = OptionValues.instance.isFullscreen;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        OptionValues.instance.isFullscreen = isFullscreen;
        Debug.Log("Vollbildmodus ist jetzt auf : " + isFullscreen);
    }

    public void PlayGameMode(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
