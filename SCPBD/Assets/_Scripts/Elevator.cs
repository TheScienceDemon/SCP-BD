using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool isInteractable;
    [SerializeField] bool isAtDest;
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

    void Start()
    {
        if (!isAtDest)
            normalElevDoor.SetBool("isOpen", true);
        else
            destElevDoor.SetBool("isOpen", true);
    }

    public IEnumerator MoveElevator()
    {
        if (!isAtDest)
        {
            isInteractable = false;
            int i = Random.Range(0, elevatorClose.Length);
            normalElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorClose[i]);
            normalElevDoor.SetBool("isOpen", false);
            yield return new WaitForSeconds(2.75f);
            normalAudioSource.PlayOneShot(elevatorTravel);
            yield return new WaitForSeconds(elevatorTravel.length - 2.75f);

            foreach (Transform objectToTravel in objectsToTravel)
                objectToTravel.position -= positionDifference;

            destAudioSource.PlayOneShot(elevatorReachDest);
            destElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorOpen[i]);
            destElevDoor.SetBool("isOpen", true);
            isAtDest = true;
            yield return new WaitForSeconds(2f);
            isInteractable = true;
        }
        else
        {
            isInteractable = false;
            int i = Random.Range(0, elevatorClose.Length);
            destElevDoor.GetComponent<AudioSource>().PlayOneShot(elevatorClose[i]);
            destElevDoor.SetBool("isOpen", false);
            yield return new WaitForSeconds(2.75f);
            destAudioSource.PlayOneShot(elevatorTravel);
            yield return new WaitForSeconds(elevatorTravel.length - 2.75f);

            foreach (Transform objectToTravel in objectsToTravel)
                objectToTravel.position += positionDifference;

            normalAudioSource.PlayOneShot(elevatorReachDest);
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
