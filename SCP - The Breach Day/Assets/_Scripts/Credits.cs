using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject creditsObj;
    [SerializeField] float scrollSpeed;
    [SerializeField] bool areCreditsActive;

    void FixedUpdate()
    {
        if (areCreditsActive)
        {
            // Do Movement
        }
        else
        {
            // Reset
        }
    }

    public void OpenCredits()
    {
        creditsObj.SetActive(true);
        areCreditsActive = true;
    }

    public void CloseCredits()
    {
        areCreditsActive = false;
        creditsObj.SetActive(false);
    }

}
