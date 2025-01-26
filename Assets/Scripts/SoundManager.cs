using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager soundManager;
	public AudioClip[] audioClips;
	public AudioSource audioSource;
	private float volume;
	private float volumeModifier;
	private void Awake()
	{

		if (soundManager == null)
		{
			soundManager = this;

		}
		else
		{
			Destroy(gameObject);
		}
	}

    private void Start()
    {
		//volumeModifier = PersitentManager.Instance.GetVolume();
		volume = 0.3f;
        audioSource.volume = volume * volumeModifier;
    }

	public void PlaySound(string clipName, bool loop = false)
	{
		AudioClip clip = System.Array.Find(audioClips, clip => clip.name == clipName);
		if (clip != null)
		{
			audioSource.PlayOneShot(clip);
		}
	}
}
