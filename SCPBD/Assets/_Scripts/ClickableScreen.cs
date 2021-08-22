using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(BoxCollider))]
public class ClickableScreen : MonoBehaviour
{
    [SerializeField] Sprite newScreenSprite;

    UserInterface ui;
    FirstPersonController fpsController;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UserInterface>();
        fpsController = FindObjectOfType<FirstPersonController>();
    }

    public void ChangeScreenState()
    {
        if (!ui.clickableScreenImage.transform.parent.gameObject.activeSelf)
        {
            fpsController.pauseMovement = true;
            fpsController.m_Input = new Vector2(0, 0);
            fpsController.m_MoveDir = new Vector3(0, 0, 0);
            ui.clickableScreenImage.transform.parent.gameObject.SetActive(true);
            ui.clickableScreenImage.sprite = newScreenSprite;
        }
        else
        {
            fpsController.pauseMovement = false;
            ui.clickableScreenImage.transform.parent.gameObject.SetActive(false);
        }
    }
}
