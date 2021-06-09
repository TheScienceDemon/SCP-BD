using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    public Transform body;
    public Animator blinkAnim;

    [Header("Blink")]
    public Slider blinkSlider;
    public TMP_Text blinkText;
    public GameObject blinkScreen;
    public float maxTimeUntilBlink;
    private float currentTimeUntilBlink;
    public float timeUntilBlinkFallRate;

    private void Start()
    {
        currentTimeUntilBlink = maxTimeUntilBlink;
        blinkSlider.maxValue = maxTimeUntilBlink;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up, mouseX);

        //Blinzel Funktionen
        if (Input.GetButton("Jump") && !GetComponentInParent<PlayerMovement>().canJump)
        {
            blinkAnim.SetBool("areEyesOpen", false);
            currentTimeUntilBlink = maxTimeUntilBlink;
        }
        
        if (Input.GetButtonUp("Jump") && !GetComponentInParent<PlayerMovement>().canJump)
        {
            blinkAnim.SetBool("areEyesOpen", true);
        }

        blinkSlider.value = currentTimeUntilBlink;
        blinkText.text = currentTimeUntilBlink.ToString("F0") + "%";
        currentTimeUntilBlink -= timeUntilBlinkFallRate * Time.deltaTime;
        if (currentTimeUntilBlink <= 0f)
        {
            StartCoroutine(Blinzeln());
        }
    }

    IEnumerator Blinzeln()
    {
        blinkAnim.SetBool("areEyesOpen", false);
        currentTimeUntilBlink = maxTimeUntilBlink;
        yield return new WaitForSeconds(.1f);
        blinkAnim.SetBool("areEyesOpen", true);
    }
}
