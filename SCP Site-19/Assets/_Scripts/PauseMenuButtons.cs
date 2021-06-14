using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GUI;
    public Animator anim;

    public void Fortfahren()
    {
        StartCoroutine(FortfahrenIEnumarator());
    }

    public void HauptMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    IEnumerator FortfahrenIEnumarator()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        anim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.1f);
        PauseMenu.SetActive(false);
        GUI.SetActive(true);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerLook>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerInteract>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PauseMenu>().isPaused = false;
    }
}
