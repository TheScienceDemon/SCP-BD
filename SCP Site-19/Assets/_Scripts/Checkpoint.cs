using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public Animator anim;
    public AudioSource CheckpointSound;
    public AudioSource LockroomSiren;
    public AudioSource Door1Open;
    public AudioSource Door2Open;
    public AudioSource Door1Close;
    public AudioSource Door2Close;
    public bool isOpen;
    public TMP_Text Button1Text;
    public TMP_Text Button2Text;

    [Header("Button Texte")]
    public string TürOffen;
    public string TürSchließt;
    public string TürZu;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Button1Text.text = "<color=#07A2FF>" + TürZu + "</color>";
        Button2Text.text = "<color=#07A2FF>" + TürZu + "</color>";
    }

    public IEnumerator CheckpointController()
    {
        isOpen = true;
        anim.SetBool("IsOpen", true);
        CheckpointSound.Play();
        Door1Open.Play();
        Door2Open.Play();
        Button1Text.text = "<color=green>" + TürOffen + "</color>";
        Button2Text.text = "<color=green>" + TürOffen + "</color>";
        yield return new WaitForSeconds(4.5f);
        LockroomSiren.Play();
        Button1Text.text = "<color=orange>" + TürSchließt + "</color>";
        Button2Text.text = "<color=orange>" + TürSchließt + "</color>";
        StartCoroutine(After1());
    }

    IEnumerator After1()
    {
        yield return new WaitForSeconds(2.75f);
        CheckpointSound.Play();
        Door1Close.Play();
        Door2Close.Play();
        anim.SetBool("IsOpen", false);
        Button1Text.text = "<color=#07A2FF>" + TürZu + "</color>";
        Button2Text.text = "<color=#07A2FF>" + TürZu + "</color>";
        StartCoroutine(After2());
    }

    IEnumerator After2()
    {
        yield return new WaitForSeconds(2f);
        isOpen = false;
    }
}
