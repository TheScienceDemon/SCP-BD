using UnityEngine;

public class LoadingScreenActivator : MonoBehaviour
{
    public void LoadScene(int index) => LoadingScreen.Singleton.LoadScene(index);
}
