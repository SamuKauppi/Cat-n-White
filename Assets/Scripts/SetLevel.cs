using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetLevel : MonoBehaviour
{
    public AudioMixer mixer; // Reference to the Audio Mixer
    public AudioSource audioSource; // Reference to the Audio Source

    void Start()
    {
        // Ensure music starts playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void SetMusicLevel(float sliderLevel)
    {
        // Adjust volume using a logarithmic scale
        if (mixer != null)
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderLevel) * 20);
        }
    }
}
