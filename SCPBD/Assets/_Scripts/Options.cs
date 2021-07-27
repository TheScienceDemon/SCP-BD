using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class Options : MonoBehaviour
{
    [SerializeField] TMP_Dropdown graphicsDropdown;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown musicDropdown;
    [SerializeField] AudioSource menuAudioSource;
    [SerializeField] AudioClip[] menuAudio;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Text volumeText;
    Resolution[] resolutionArray;

    // Start is called before the first frame update
    void Start()
    {
        // Grafik Einstellungen
        graphicsDropdown.value = QualitySettings.GetQualityLevel();
        graphicsDropdown.RefreshShownValue();

        // Hauptmenü Musik
        musicDropdown.ClearOptions();
        List<string> musicOptions = new List<string>();
        for (int i = 0; i < menuAudio.Length; i++)
        {
            musicOptions.Add(menuAudio[i].name);
        }
        musicDropdown.AddOptions(musicOptions);
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

    public void SetQualityLevel(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
        Debug.Log("Qualitätsstufe ist jetzt auf : " + QualitySettings.GetQualityLevel());
    }

    public void SetMenuMusic(int musicIndex)
    {
        menuAudioSource.clip = menuAudio[musicIndex];
        menuAudioSource.Play();
        Debug.Log("Hauptmenumusik ist jetzt : " + menuAudioSource.clip.name);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        volumeText.text = "Lautstärke - " + (volume * 100).ToString("F0") + "%";
        Debug.Log("Volume ist jetzt auf : " + (volume * 100).ToString("F0"));
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionArray[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("Auflösung ist jetzt auf : " + resolution);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
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
