using UnityEngine;

public class Hint : MonoBehaviour
{
    [SerializeField] GameObject hintText;

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.N)) { return; }

        if (hintText.activeSelf) hintText.SetActive(false);
        else hintText.SetActive(true);
    }
}
