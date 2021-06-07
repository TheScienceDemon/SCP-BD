using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public GameObject normalPanel;
    public GameObject LoadingPanel;
    public Slider progressSlider;
    public TMP_Text progressText;


    public void LoadScene (int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        normalPanel.SetActive(false);
        LoadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progressSlider.value = progress;
            progress = progress * 100f;
            progressText.text = progress.ToString("F2") + "%";
            yield return null;
        }
    }
}
