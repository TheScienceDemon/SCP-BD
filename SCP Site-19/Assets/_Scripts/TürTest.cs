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
    [TextArea(1, 1)] public string TürZu;
    [TextArea(1, 1)]public string TürOffen;
    [TextArea(1, 1)] public string TürGesperrt;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip[] open;
    public AudioClip[] close;
    [SerializeField] private AudioClip clip;

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

        if (isOpen)
        {
            anim.SetBool("IsOpen", true);
        }
    }

    void LateUpdate()
    {
        if (text)
        {
            if (!hasPower)
            {
                Button1Text.fontSize = .014f;
                Button2Text.fontSize = .014f;
                Button1Text.text = TürGesperrt;
                Button2Text.text = TürGesperrt;
            }
            else
            {
                if (isOpen)
                {
                    Button1Text.fontSize = .02f;
                    Button2Text.fontSize = .02f;
                    Button1Text.text = TürOffen;
                    Button2Text.text = TürOffen;
                }
                else
                {
                    Button1Text.fontSize = .015f;
                    Button2Text.fontSize = .015f;
                    Button1Text.text = TürZu;
                    Button2Text.text = TürZu;
                }
            }
        }
    }

    public IEnumerator TürÖffnen()
    {
        isInteractable = false;
        TürÖffnenSfx();
        anim.SetBool("IsOpen", true);
        isOpen = true;
        yield return new WaitForSeconds(unInteractableTime);
        isInteractable = true;
    }

    public IEnumerator TürSchließen()
    {
        isInteractable = false;
        TürSchließenSfx();
        anim.SetBool("IsOpen", false);
        isOpen = false;
        yield return new WaitForSeconds(unInteractableTime);
        isInteractable = true;
    }

    void TürÖffnenSfx()
    {
        int index = Random.Range(0, open.Length);
        clip = open[index];
        audioSource.PlayOneShot(clip, Random.Range(0f, 1f));
    }

    void TürSchließenSfx()
    {
        int index = Random.Range(0, close.Length);
        clip = close[index];
        audioSource.PlayOneShot(clip, Random.Range(0f, 1f));
    }
}
