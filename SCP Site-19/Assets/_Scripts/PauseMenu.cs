using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;

    public GameObject pauseMenu;
    public GameObject Gui;
    public Animator anim;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = !isPaused;
            MenuOpen();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = !isPaused;
            StartCoroutine(MenuClose());
        }
    }

    void MenuOpen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        Gui.SetActive(false);
        anim.SetBool("IsOpen", true);
        GetComponent<PlayerLook>().enabled = false;
        GetComponent<PlayerInteract>().enabled = false;
    }

    IEnumerator MenuClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        AudioListener.pause =false;
        anim.SetBool("IsOpen", false);
        yield return new WaitForSeconds(0.1f);
        pauseMenu.SetActive(false);
        Gui.SetActive(true);
        GetComponent<PlayerLook>().enabled = true;
        GetComponent<PlayerInteract>().enabled = true;
    }
}
