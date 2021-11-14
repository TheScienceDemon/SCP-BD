using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    public static DebugMenu Singleton { get; private set; }

    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Text gameVersion;
    [SerializeField] TMP_Text unityVersion;
    [SerializeField] TMP_Text frameRate;
    [SerializeField] TMP_Text date;
    [SerializeField] TMP_Text time;

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

    // Start is called before the first frame update
    void Start()
    {
        gameVersion.text += Application.version;
        unityVersion.text += Application.unityVersion;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
            canvas.SetActive(!canvas.activeInHierarchy);

        deltaTime += (Time.deltaTime - deltaTime) * 0.01f;
        float fps = 1f / deltaTime;
        frameRate.text = "FPS: " + Mathf.Ceil(fps).ToString();

        date.text = "<size=42>Date:</size> " + System.DateTime.Now.ToString("dd MMMM yyyy");

        time.text = "Time: " + System.DateTime.Now.ToString("HH:mm:ss");
    }
}
