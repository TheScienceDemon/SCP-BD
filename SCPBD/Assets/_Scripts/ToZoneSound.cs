using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider))]
public class ToZoneSound : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            source.PlayOneShot(clip);
    }
}
