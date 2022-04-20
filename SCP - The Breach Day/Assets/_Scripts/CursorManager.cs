using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static bool pauseMenu;

    void LateUpdate() {
        bool b = pauseMenu;

        Cursor.visible = b;
        Cursor.lockState = b ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
