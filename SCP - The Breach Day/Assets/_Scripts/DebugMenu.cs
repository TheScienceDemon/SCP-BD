using TMPro;
using UnityEngine;

#pragma warning disable IDE0044
public class DebugMenu : MonoBehaviour
{
    public static DebugMenu Singleton { get; private set; }

    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text gameVersion;
    [SerializeField] TMP_Text buildGUID;
    [SerializeField] TMP_Text unityVersion;
    [SerializeField] TMP_Text frameRate;
    [SerializeField] TMP_Text ramUsage;
    [SerializeField] TMP_Text date;
    [SerializeField] TMP_Text time;

    float deltaTime;

    void Awake() {
        if (Singleton == null) {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        gameVersion.text += Application.version;
        buildGUID.text += string.IsNullOrEmpty(Application.buildGUID)
            ? "In Editor"
            : Application.buildGUID;
        unityVersion.text += Application.unityVersion;
    }

    void Update() {
        if (Input.GetKeyDown(SaveDataManager.GetKey(ActionName.OpenDebugMenu)))
            canvas.SetActive(!canvas.activeSelf);

        deltaTime += (Time.deltaTime - deltaTime) * 0.01f;
        float fps = 1f / deltaTime;

        frameRate.text = $"FPS: {Mathf.Ceil(fps)}";

        date.text = $"Date: {System.DateTime.Now:dd MMMM yyyy}";

        time.text = $"Time: {System.DateTime.Now:HH:mm:ss}";

        ramUsage.text = $"Ram usage: {System.GC.GetTotalMemory(false)}";
    }
}
