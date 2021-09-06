using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Scp914 : MonoBehaviour
{
    public enum Scp914Modes { Rough, Coarse, OneToOne, Fine, VeryFine};
    public Scp914Modes Scp914mode;
    public List<GameObject> objectsToRefine;
    Animator anim;
    [SerializeField] AudioSource normalSource;
    [SerializeField] AudioSource intakeSource;
    [SerializeField] AudioSource outputSource;
    [SerializeField] AudioClip refine;
    [SerializeField] AudioClip doorClose;
    [SerializeField] AudioClip doorOpen;

    public bool isRefining;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator Refine()
    {
        isRefining = true;
        normalSource.PlayOneShot(refine);
        outputSource.PlayOneShot(doorClose);
        yield return new WaitForSeconds(doorClose.length / 2f);
        intakeSource.PlayOneShot(doorClose);
        yield return new WaitForSeconds(refine.length - (doorClose.length / 2f) - 3f);
        intakeSource.PlayOneShot(doorOpen);
        outputSource.PlayOneShot(doorOpen);
        isRefining = false;
    }
}
