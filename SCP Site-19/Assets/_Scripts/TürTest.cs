using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TürTest : MonoBehaviour
{
    public bool isOpen;
    public bool isInteractable;
    public bool hasPower;
    public bool isRandomOpen;
    public bool shouldDisableAnAudiosource;
    public bool text;
    [Range(0f, 1f)]public float randomOpenChance;
    public float unInteractableTime;
    public Animator anim;
    public TMP_Text Button1Text;
    public TMP_Text Button2Text;
    public GameObject AudiosourceToDisable;

    [Header("Button Texte")]
    [TextArea]public string TürZu;
    [TextArea]public string TürOffen;
    [TextArea]public string TürGesperrt;

    [Header("Tür Öffnen Sounds")]
    public AudioSource DoorOpen1;
    public AudioSource DoorOpen2;
    public AudioSource DoorOpen3;

    [Header("Tür Schließen Sounds")]
    public AudioSource DoorClose1;
    public AudioSource DoorClose2;
    public AudioSource DoorClose3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (isRandomOpen)
        {
            if (Random.value <= randomOpenChance)
            {
                isOpen = true;
                AudiosourceToDisable.SetActive(false);
                anim.SetBool("IsOpen", true);
            }
        }

        if (text)
        {
            if (isOpen)
            {
                Button1Text.text = "<color=green>" + TürOffen + "</color>";
                Button2Text.text = "<color=green>" + TürOffen + "</color>";
            }
            else
            {
                Button1Text.text = "<color=#07A2FF>" + TürZu + "</color>";
                Button2Text.text = "<color=#07A2FF>" + TürZu + "</color>";
            }
        }

        if (isOpen)
        {
            anim.SetBool("IsOpen", true);
        }
    }

    void Update()
    {
        if (text)
        {
            if (!hasPower)
            {
                Button1Text.fontSize = .014f;
                Button2Text.fontSize = .014f;
                Button1Text.text = "<color=red>" + TürGesperrt + "</color>";
                Button2Text.text = "<color=red>" + TürGesperrt + "</color>";
            }
            else
            {
                if (isOpen)
                {
                    Button1Text.fontSize = .02f;
                    Button2Text.fontSize = .02f;
                    Button1Text.text = "<color=green>" + TürOffen + "</color>";
                    Button2Text.text = "<color=green>" + TürOffen + "</color>";
                }
                else
                {
                    Button1Text.fontSize = .015f;
                    Button2Text.fontSize = .015f;
                    Button1Text.text = "<color=#07A2FF>" + TürZu + "</color>";
                    Button2Text.text = "<color=#07A2FF>" + TürZu + "</color>";
                }
            }
        }
    }

    public void TürÖffnen()
    {
        StartCoroutine(TürÖffnenIEnumerator());
    }

    public void TürSchließen()
    {
        StartCoroutine(TürSchließenIEnumerator());
    }

    IEnumerator TürÖffnenIEnumerator()
    {
        isInteractable = false;
        TürÖffnerSoundRandomizer();
        anim.SetBool("IsOpen", true);
        isOpen = true;
        if (text)
        {
            Button1Text.text = "<color=green>" + TürOffen + "</color>";
            Button2Text.text = "<color=green>" + TürOffen + "</color>";
        }
        yield return new WaitForSeconds(unInteractableTime);
        isInteractable = true;
    }

    IEnumerator TürSchließenIEnumerator()
    {
        isInteractable = false;
        TürSchließerSoundRandomizer();
        anim.SetBool("IsOpen", false);
        isOpen = false;
        if (text)
        {
            Button1Text.text = "<color=#07A2FF>" + TürZu + "</color>";
            Button2Text.text = "<color=#07A2FF>" + TürZu + "</color>";
        }
        yield return new WaitForSeconds(unInteractableTime);
        isInteractable = true;
    }

    void TürÖffnerSoundRandomizer()
    {
        if (Random.value <= 0.4f)
        {
            DoorOpen1.Play();
        }
        else
        {
            if (Random.value <= 0.4f)
            {
                DoorOpen2.Play();
            }
            else
            {
                if (Random.value <= 1f)
                {
                    DoorOpen3.Play();
                }
            }
        }
    }

    void TürSchließerSoundRandomizer()
    {
        if (Random.value <= 0.4f)
        {
            DoorClose1.Play();
        }
        else
        {
            if (Random.value <= 0.4f)
            {
                DoorClose2.Play();
            }
            else
            {
                if (Random.value <= 1f)
                {
                    DoorClose3.Play();
                }
            }
        }
    }
}
