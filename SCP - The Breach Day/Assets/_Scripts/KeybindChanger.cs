using UnityEngine;

public class KeybindChanger : MonoBehaviour
{
    [SerializeField] ActionName action;

    TMPro.TMP_Text buttonText;
//  bool startedRebinding = false;

    public void Init()
    {
        buttonText = GetComponentInChildren<TMPro.TMP_Text>();

        KeyCode keycode = SaveDataManager.GetKey(action);
        buttonText.text = keycode.ToString();
    }

    public void StartRebind()
    {
        buttonText.text = "> ... <";
    }
}
