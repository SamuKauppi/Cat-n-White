using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager soundManager;
	public AudioClip[] audioClips;
	public AudioSource audioSource;
	public float volume;
	private void Awake()
	{
		volume = 0.3f;

		if (soundManager == null)
		{
			soundManager = this;

		}
		else
		{
			Destroy(gameObject);
		}
	}
	private void Update()
	{
		audioSource.volume = volume;
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
