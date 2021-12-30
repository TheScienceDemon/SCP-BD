using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] Image background;
    public bool areCreditsActive;
    [SerializeField] float fadeSpeed;
    [SerializeField] RectTransform textObj;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    void Start()
    {
        background.color = new Color(
            background.color.r,
            background.color.g,
            background.color.b,
            0f);
        textObj.position = startPos;
    }

    void OnEnable() => areCreditsActive = true;

    void OnDisable()
    {
        areCreditsActive = false;
        textObj.position = startPos;
    }

    void FixedUpdate()
    {
        if (areCreditsActive)
        {
            var tempColor = background.color;
            tempColor.a = Mathf.Lerp(tempColor.a, 1f, Time.time * fadeSpeed);
            background.color = tempColor;

            textObj.position += Vector3.up * 1.5f;
        }
    }

}
