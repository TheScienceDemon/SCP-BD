using TMPro;
using UnityEngine;

#pragma warning disable IDE0044
public class DebugMenu : MonoBehaviour
{
    public static DebugMenu Singleton { get; private set; }

    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text gameVersion;
    [SerializeField] TMP_Text unityVersion;
    [SerializeField] TMP_Text frameRate;
    [SerializeField] TMP_Text date;
    [SerializeField] TMP_Text time;
    [SerializeField] TMP_Text cpu;
    [SerializeField] TMP_Text gpu;
    [SerializeField] TMP_Text ram;
    [SerializeField] TMP_Text os;

    float deltaTime;

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

    void Start()
    {
        gameVersion.text += Application.version;
        unityVersion.text += Application.unityVersion;
        cpu.text += SystemInfo.processorType;
        gpu.text += SystemInfo.graphicsDeviceName;
        os.text += SystemInfo.operatingSystem;
    }

    void Update()
    {
        if (Input.GetKeyDown(SaveDataManager.GetKey(ActionName.OpenDebugMenu)))
            canvas.SetActive(!canvas.activeSelf);

        deltaTime += (Time.deltaTime - deltaTime) * 0.01f;
        float fps = 1f / deltaTime;

        frameRate.text = $"FPS: {Mathf.Ceil(fps)}";

        date.text = $"Date: {System.DateTime.Now:dd MMMM yyyy}";

        time.text = $"Time: {System.DateTime.Now:HH:mm:ss}";

        ram.text = $"Ram usage: {System.GC.GetTotalMemory(false)}";
    }
}
