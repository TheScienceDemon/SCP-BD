using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    public Transform body;

    [Header("Blink")]
    public Slider blinkSlider;
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

        blinkSlider.value = currentTimeUntilBlink;
        currentTimeUntilBlink -= timeUntilBlinkFallRate * Time.deltaTime;
        if (currentTimeUntilBlink <= 0f)
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        blinkScreen.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        currentTimeUntilBlink = maxTimeUntilBlink;
        blinkScreen.SetActive(false);
    }
}
