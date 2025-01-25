using UnityEngine;

public class PersitentManager : MonoBehaviour
{
    public static PersitentManager Instance { get; private set; }

    private float volume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("volume", 1f);
    }

    public void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        this.volume = volume;
    }

    public float GetVolume()
    {
        return volume;
    }
}
