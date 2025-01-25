using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetLevel : MonoBehaviour
{
    public AudioMixer mixer; // Reference to the Audio Mixer
    public AudioSource audioSource; // Reference to the Audio Source

    [SerializeField] private Slider audioSlider;

    void Start()
    {
        // Ensure music starts playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        float value = PersitentManager.Instance.GetVolume();
        audioSlider.value = value;
    }

    public void SetMusicLevel(float sliderLevel)
    {
        // Adjust volume using a logarithmic scale
        if (mixer != null)
        {
            mixer.SetFloat("MusicVol", Mathf.Log10(sliderLevel) * 20);
            PersitentManager.Instance.ChangeVolume(sliderLevel);
        }
    }
}
