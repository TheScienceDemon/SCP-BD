using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Singleton { get; private set; }

    [SerializeField] GameObject canvasObj;
    [SerializeField] Slider progressBarSlider;
    [SerializeField] Image progressBarImage;
    [SerializeField] TMP_Text progressBarText;
    [SerializeField] TMP_Text label;

    // Awake is called before Start
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LoadScene(int index) => StartCoroutine(LoadSceneEnumerator(index));

    IEnumerator LoadSceneEnumerator(int index)
    {
        progressBarSlider.value = 0f;
        progressBarImage.fillAmount = 0f;
        progressBarText.text = "0%";
        label.text = string.Empty;

        var scene = SceneManager.GetSceneByBuildIndex(index);
        var asyncScene = SceneManager.LoadSceneAsync(index);

        canvasObj.SetActive(true);
        label.text = $"Loading scene {scene.name} . . .";

        do
        {
            float progress = Mathf.Clamp01(asyncScene.progress / .9f);

            progressBarSlider.value = progress;
            progressBarImage.fillAmount = progress;
            progressBarText.text = $"{progress * 100f}%";

            yield return null;
        } while (!asyncScene.isDone);

        canvasObj.SetActive(false);
    }
}
