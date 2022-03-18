using UnityEngine;

public class Loader : MonoBehaviour
{
    void Start() =>
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Startup);
}
