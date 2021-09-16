using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scp914 : MonoBehaviour
{
    public bool isRefining;
    public Scp914Modes Scp914mode;
    public List<GameObject> objectsToRefine;
    [SerializeField] Animator intakeAnim;
    [SerializeField] Animator outputAnim;
    [SerializeField] AudioSource normalSource;
    [SerializeField] AudioSource intakeSource;
    [SerializeField] AudioSource outputSource;
    [SerializeField] AudioClip refine;
    [SerializeField] AudioClip doorClose;
    [SerializeField] AudioClip doorOpen;
    
    public enum Scp914Modes { Rough, Coarse, OneToOne, Fine, VeryFine};

    public IEnumerator Refine()
    {
        isRefining = true;
        normalSource.PlayOneShot(refine);
        outputSource.PlayOneShot(doorClose);
        outputAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(doorClose.length / 2f);
        intakeSource.PlayOneShot(doorClose);
        intakeAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(refine.length - (doorClose.length / 2f) - 6f);
        UseUpgradeTree();
        yield return new WaitForSeconds(3f);
        intakeSource.PlayOneShot(doorOpen);
        intakeAnim.SetBool("isOpen", true);
        outputSource.PlayOneShot(doorOpen);
        outputAnim.SetBool("isOpen", true);
        isRefining = false;
    }

    void UseUpgradeTree()
    {
        foreach (GameObject item in objectsToRefine)
        {
            if (item.GetComponent<ItemInfo>() == null) return;

            if (Scp914mode == Scp914Modes.Rough)
                Instantiate(item.GetComponent<ItemInfo>().scp914UpgradeTree.OutputRough,
                    outputSource.transform.position, Quaternion.identity);

            else if (Scp914mode == Scp914Modes.Coarse)
                Instantiate(item.GetComponent<ItemInfo>().scp914UpgradeTree.OutputCoarse,
                    outputSource.transform.position, Quaternion.identity);

            else if (Scp914mode == Scp914Modes.OneToOne)
                Instantiate(item.GetComponent<ItemInfo>().scp914UpgradeTree.OutputOneToOne,
                    outputSource.transform.position, Quaternion.identity);

            else if (Scp914mode == Scp914Modes.Fine)
                Instantiate(item.GetComponent<ItemInfo>().scp914UpgradeTree.OutputFine,
                    outputSource.transform.position, Quaternion.identity);

            else if (Scp914mode == Scp914Modes.VeryFine)
                Instantiate(item.GetComponent<ItemInfo>().scp914UpgradeTree.OutputVeryFine,
                    outputSource.transform.position, Quaternion.identity);

            Destroy(item);
        }
    }
}
