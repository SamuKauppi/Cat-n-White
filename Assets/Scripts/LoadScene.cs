using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public float delayBeforeLoad = 0.1f; // Delay in seconds

	[SerializeField] private AudioSource endMusic;

    private void Start()
    {
        endMusic.volume = PersitentManager.Instance.GetVolume() * 0.3f;
    }

    public void StartLoad(int index)
    {
        StartCoroutine(LoadSceneWithDelay(index));
    }

    private IEnumerator LoadSceneWithDelay(int index)
    {
        yield return new WaitForSeconds(delayBeforeLoad); // Wait for the specified delay
        SceneManager.LoadScene(index); // Load the scene after the delay
    }
}
