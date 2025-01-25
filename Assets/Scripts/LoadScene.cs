using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void StartLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
}
