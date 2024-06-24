using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliderf : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioMixer mixer;
    [SerializeField] string mixerGroup;

    void Start()
    {
        SetVolume();
    }




    public void SetVolume()
    {
        float _volume = volumeSlider.value;
        mixer.SetFloat(mixerGroup, Mathf.Log10(_volume) * 20);
    }
}
