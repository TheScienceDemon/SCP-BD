using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int i;

    public void SceneLoadButton()
    {
        SceneManager.LoadScene(i, LoadSceneMode.Single);
    }
}
