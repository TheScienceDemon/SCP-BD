#if UNITY_EDITOR
using UnityEditor.Experimental.SceneManagement;
#endif
using UnityEngine;

public class DoorSpawnpoint : MonoBehaviour
{
    public DoorTypesEnum doorType;
    public AccessTypes[] accessTypes;

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (UnityEditor.EditorApplication.isPlaying) { return; }
        if (PrefabStageUtility.GetCurrentPrefabStage() == null) { return; }

        Gizmos.DrawWireSphere(
                transform.position,
                FindObjectOfType<DoorSpawner>().colliderRadius);
    }
#endif
}
