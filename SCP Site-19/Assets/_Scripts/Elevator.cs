using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator animAufzugUnten;
    public Animator animAufzugOben;
    public GameObject AufzugUntenTeleport;
    public GameObject AufzugObenTeleport;
    public GameObject Player;
    public float elevWaitingTime;
    public float unIteractableTime;
    public bool isElevatorDown;
    public bool isInteractable;
    public bool isPlayerInElevator;

    [Header("Oberer Aufzug ÷ffnungs Sounds")]
    public AudioSource UpperElevOpen1;
    public AudioSource UpperElevOpen2;
    public AudioSource UpperElevOpen3;

    [Header("Oberer Aufzug Schlieﬂungs Sounds")]
    public AudioSource UpperElevClose1;
    public AudioSource UpperElevClose2;
    public AudioSource UpperElevClose3;

    [Header("Unterer Aufzug ÷ffnungs Sounds")]
    public AudioSource LowerElevOpen1;
    public AudioSource LowerElevOpen2;
    public AudioSource LowerElevOpen3;

    [Header("Unterer Aufzug Schlieﬂungs Sounds")]
    public AudioSource LowerElevClose1;
    public AudioSource LowerElevClose2;
    public AudioSource LowerElevClose3;

    private void Start()
    {
        animAufzugOben.SetBool("IsOpen", !isElevatorDown);
        animAufzugUnten.SetBool("IsOpen", isElevatorDown);
    }

    public IEnumerator AufzugController()
    {
        if (isElevatorDown)
        {
            isInteractable = false;
            AufzugUntenSchlieﬂerSoundRandomizer();
            animAufzugUnten.SetBool("IsOpen", false);
            yield return new WaitForSeconds(elevWaitingTime);
            if (isPlayerInElevator)
            {
                Player.SetActive(false);
                Player.transform.position = AufzugObenTeleport.transform.position;
                Player.SetActive(true);
                isElevatorDown = false;
            }
            else
            {
                isElevatorDown = false;
            }
            StartCoroutine(AufzugUnten());
        }
        else
        {
            isInteractable = false;
            AufzugObenSchlieﬂerSoundRandomizer();
            animAufzugOben.SetBool("IsOpen", false);
            yield return new WaitForSeconds(elevWaitingTime);
            if (isPlayerInElevator)
            {
                Player.SetActive(false);
                Player.transform.position = AufzugUntenTeleport.transform.position;
                Player.SetActive(true);
                isElevatorDown = true;
            }
            else
            {
                isElevatorDown = true;
            }
            StartCoroutine(AufzugOben());
        }
    }

    IEnumerator AufzugUnten()
    {
        yield return new WaitForSeconds(1f);
        AufzugOben÷ffnerSoundRandomizer();
        animAufzugOben.SetBool("IsOpen", true);
        StartCoroutine(InteractPause());
        StartCoroutine(WaitForSteps());
    }

    IEnumerator AufzugOben()
    {
        yield return new WaitForSeconds(1f);
        AufzugUnten÷ffnerSoundRandomizer();
        animAufzugUnten.SetBool("IsOpen", true);
        StartCoroutine(InteractPause());
        StartCoroutine(WaitForSteps());
    }

    IEnumerator InteractPause()
    {
        yield return new WaitForSeconds(unIteractableTime);
        isInteractable = true;
    }

    IEnumerator WaitForSteps()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isMakingSteps)
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isMakingSteps = false;
    }

    void AufzugUnten÷ffnerSoundRandomizer()
    {
        if (Random.value <= 0.4f)
        {
            LowerElevOpen1.Play();
        }
        else
        {
            if (Random.value <= 0.4f)
            {
                LowerElevOpen2.Play();
            }
            else
            {
                if (Random.value <= 1f)
                {
                    LowerElevOpen3.Play();
                }
            }
        }
    }

    void AufzugUntenSchlieﬂerSoundRandomizer()
    {
        if (Random.value <= 0.4f)
        {
            LowerElevClose1.Play();
        }
        else
        {
            if (Random.value <= 0.4f)
            {
                LowerElevClose2.Play();
            }
            else
            {
                if (Random.value <= 1f)
                {
                    LowerElevClose3.Play();
                }
            }
        }
    }

    void AufzugOben÷ffnerSoundRandomizer()
    {
        if (Random.value <= 0.4f)
        {
            UpperElevOpen1.Play();
        }
        else
        {
            if (Random.value <= 0.4f)
            {
                UpperElevOpen2.Play();
            }
            else
            {
                if (Random.value <= 1f)
                {
                    UpperElevOpen3.Play();
                }
            }
        }
    }

    void AufzugObenSchlieﬂerSoundRandomizer()
    {
        if (Random.value <= 0.4f)
        {
            UpperElevClose1.Play();
        }
        else
        {
            if (Random.value <= 0.4f)
            {
                UpperElevClose2.Play();
            }
            else
            {
                if (Random.value <= 1f)
                {
                    UpperElevClose3.Play();
                }
            }
        }
    }
}
