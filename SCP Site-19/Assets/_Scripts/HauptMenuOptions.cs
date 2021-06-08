using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class HauptMenuOptions : MonoBehaviour
{
    public AudioMixer mainAudioMix;
    public TMP_Dropdown resDropdown;
    public TMP_Text volumeText;
    private Resolution[] resolutionArray;

    private void Start()
    {
        #region Resolution
        resolutionArray = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> resDropdownOptions = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutionArray.Length; i++)
        {
            string resDropdownOption = resolutionArray[i].width + " x " + resolutionArray[i].height;
            resDropdownOptions.Add(resDropdownOption);

            if (resolutionArray[i].width == Screen.currentResolution.width && resolutionArray[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(resDropdownOptions);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
        #endregion
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutionArray[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        mainAudioMix.SetFloat("volume", volume);
        volumeText.text = volume.ToString("F2") + " db";
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
