using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStartSceneLoader : MonoBehaviour
{
    public int sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
