using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool isInteractable;
    [SerializeField] bool isAtDest;
    [SerializeField] float elevatorTravelSoundChangeTime;
    [SerializeField] Vector3 positionDifference;
    [SerializeField] List<Transform> objectsToTravel;

    [Header("Animator")]
    [SerializeField] Animator normalElevDoor;
    [SerializeField] Animator destElevDoor;

    [Header("AudioSources")]
    [SerializeField] AudioSource normalAudioSource;
    [SerializeField] AudioSource destAudioSource;

    [Header("Sounds")]
    [SerializeField] AudioClip elevatorTravel;
    [SerializeField] AudioClip elevatorReachDest;
    [SerializeField] AudioClip[] elevatorOpen;
    [SerializeField] AudioClip[] elevatorClose;

    [Header("Elevator Buttons")]
    [SerializeField] Renderer[] normalButtons;
    [SerializeField] Renderer[] destButtons;

    [Header("Materials")]
    [SerializeField] Material buttonOpen;
    [SerializeField] Material buttonClose;
    [SerializeField] Material buttonLocked;

    void Start()
    {
        if (!isAtDest)
        {
            normalElevDoor.SetBool("isOpen", true);

            foreach (Renderer button in destButtons)
                button.material = buttonClose;
        }
        else
        {
            destElevDoor.SetBool("isOpen", true);

            foreach (Renderer button in normalButtons)
                button.material = buttonClose;
        }
    }

    public IEnumerator MoveElevator()
    {
        if (!isAtDest)
        {
            int i = Random.Range(0, elevatorClose.Length);
            isInteractable = false;

            foreach (Renderer button in normalButtons)
                button.material = buttonClose;

            normalElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorClose[i]);
            normalElevDoor.SetBool("isOpen", false);
            yield return new WaitForSeconds(2.75f);

            foreach (Renderer button in normalButtons)
                button.material = buttonLocked;

            foreach (Renderer button in destButtons)
                button.material = buttonLocked;

            normalAudioSource.volume = 1f;
            normalAudioSource.PlayOneShot(elevatorTravel);
            destAudioSource.volume = .1f;
            destAudioSource.PlayOneShot(elevatorTravel);
            yield return new WaitForSeconds((elevatorTravel.length / 2) - elevatorTravelSoundChangeTime);

            foreach (Transform objectToTravel in objectsToTravel)
                objectToTravel.position -= positionDifference;

            normalAudioSource.volume = 0.1f;
            destAudioSource.volume = 1f;
            yield return new WaitForSeconds((elevatorTravel.length / 2) - 2f + elevatorTravelSoundChangeTime);

            destAudioSource.PlayOneShot(elevatorReachDest);

            foreach (Renderer button in normalButtons)
                button.material = buttonClose;

            foreach (Renderer button in destButtons)
                button.material = buttonOpen;

            destElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorOpen[i]);
            destElevDoor.SetBool("isOpen", true);
            isAtDest = true;
            yield return new WaitForSeconds(2f);
            isInteractable = true;
        }
        else
        {
            int i = Random.Range(0, elevatorClose.Length);
            isInteractable = false;

            foreach (Renderer button in destButtons)
                button.material = buttonClose;

            destElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorClose[i]);
            destElevDoor.SetBool("isOpen", false);
            yield return new WaitForSeconds(2.75f);

            foreach (Renderer button in normalButtons)
                button.material = buttonLocked;

            foreach (Renderer button in destButtons)
                button.material = buttonLocked;

            destAudioSource.volume = 1f;
            destAudioSource.PlayOneShot(elevatorTravel);
            normalAudioSource.volume = .1f;
            normalAudioSource.PlayOneShot(elevatorTravel);
            yield return new WaitForSeconds((elevatorTravel.length / 2) - elevatorTravelSoundChangeTime);

            foreach (Transform objectToTravel in objectsToTravel)
                objectToTravel.position += positionDifference;

            destAudioSource.volume = 0.1f;
            normalAudioSource.volume = 1f;
            yield return new WaitForSeconds((elevatorTravel.length / 2) - 2f + elevatorTravelSoundChangeTime);

            normalAudioSource.PlayOneShot(elevatorReachDest);

            foreach (Renderer button in destButtons)
                button.material = buttonClose;

            foreach (Renderer button in normalButtons)
                button.material = buttonOpen;

            normalElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorOpen[i]);
            normalElevDoor.SetBool("isOpen", true);
            isAtDest = false;
            yield return new WaitForSeconds(2f);
            isInteractable = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!objectsToTravel.Contains(other.transform))
            objectsToTravel.Add(other.transform);
    }

    void OnTriggerExit(Collider other)
    {
        if (objectsToTravel.Contains(other.transform))
            objectsToTravel.Remove(other.transform);
    }
}
